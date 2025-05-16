using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProiectPractica.Components.Account;
using ProiectPractica.Data;
using ProiectPractica.Entities;
using ProiectPractica.Interfaces;
using ProiectPractica.Repository;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddHttpClient();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddRazorPages();
builder.Services.AddMudServices();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

// Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = IdentityConstants.ApplicationScheme;
    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
})
.AddIdentityCookies();

// DbContext
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Identity with AppUserEntity
builder.Services.AddIdentityCore<AppUserEntity>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddSignInManager()
.AddDefaultTokenProviders();

// Email sender
builder.Services.Configure<AuthMessageSenderOptions>(builder.Configuration);
builder.Services.AddSingleton<IEmailSender<AppUserEntity>, EmailSender>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddLogging();

// Other services
builder.Services.AddScoped<IRepository<SubcontractorEntity>, Repository<SubcontractorEntity>>();
builder.Services.AddScoped<IRepository<ProiectEntity>, Repository<ProiectEntity>>();
builder.Services.AddScoped<IRepository<UserSelectedProject>, Repository<UserSelectedProject>>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new() { Title = "API Proiect Practica", Version = "v1" });
});

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Proiect Practica v1"));
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();
app.UseAuthentication();
app.UseAuthorization();

// Routes
app.MapRazorComponents<ProiectPractica.App>()
    .AddInteractiveServerRenderMode();
app.MapRazorPages();
app.MapAdditionalIdentityEndpoints();

// Apply migrations
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate();
}

// API endpoint
app.MapDelete("/api/proiecte/{id:int}", async (int id, ApplicationDbContext db) =>
{
    var proiect = await db.Proiecte.FindAsync(id);
    if (proiect == null)
        return Results.NotFound();
    db.Proiecte.Remove(proiect);
    await db.SaveChangesAsync();
    return Results.Ok();
});

app.Run();