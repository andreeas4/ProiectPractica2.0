using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProiectPractica.Components.Account;
using ProiectPractica.Data;
using ProiectPractica.Entities;
using ProiectPractica.Interfaces;
using ProiectPractica.Repository;
using MudBlazor.Services;
using ProiectPractica.Services;

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
builder.Services.AddLogging(logging =>
{
    logging.AddConsole();
    logging.AddDebug();
    logging.SetMinimumLevel(LogLevel.Information);
});

// Other services
builder.Services.AddScoped<IRepository<SubcontractorEntity>, Repository<SubcontractorEntity>>();
builder.Services.AddScoped<IRepository<ProiectEntity>, Repository<ProiectEntity>>();
builder.Services.AddScoped<IRepository<UserSelectedProject>, Repository<UserSelectedProject>>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IRepository<ActAditionalEntity>, Repository<ActAditionalEntity>>();
builder.Services.AddScoped<IRepository<PrelungireContractEntity>, Repository<PrelungireContractEntity>>();
builder.Services.AddScoped<IRepository<ModificareValoareEntity>, Repository<ModificareValoareEntity>>();
builder.Services.AddScoped<IRepository<ModificareLivrabileEntity>, Repository<ModificareLivrabileEntity>>();
builder.Services.AddScoped<IRepository<LivrabilEntity>, Repository<LivrabilEntity>>();
builder.Services.AddScoped<IRepository<TaskProiectEntity>, Repository<TaskProiectEntity>>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddHostedService<BackgroundNotificationService>();
builder.Services.AddSignalR();
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
app.UseRouting(); // Ensure routing is added before authentication/authorization
app.UseAntiforgery();
app.UseAuthentication();
app.UseAuthorization();

// Routes
app.MapRazorComponents<ProiectPractica.App>()
    .AddInteractiveServerRenderMode();
app.MapRazorPages();
app.MapAdditionalIdentityEndpoints();
app.MapHub<NotificationHub>("/notificationHub"); // Add SignalR hub mapping

// Apply migrations with error handling
using (var scope = app.Services.CreateScope())
{
    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
    try
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        dbContext.Database.Migrate();
        logger.LogInformation("Database migrations applied successfully.");
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "Failed to apply database migrations.");
        throw; // Re-throw to stop the app if migrations fail
    }
}

// API endpoint with error handling
app.MapDelete("/api/proiecte/{id:int}", async (int id, ApplicationDbContext db, ILogger<Program> logger) =>
{
    try
    {
        var proiect = await db.Proiecte.FindAsync(id);
        if (proiect == null)
        {
            logger.LogWarning("Project with ID {Id} not found.", id);
            return Results.NotFound();
        }

        db.Proiecte.Remove(proiect);
        await db.SaveChangesAsync();
        logger.LogInformation("Project with ID {Id} deleted successfully.", id);
        return Results.Ok();
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "Failed to delete project with ID {Id}.", id);
        return Results.Problem("An error occurred while deleting the project.");
    }
}).RequireAuthorization();

app.Run();