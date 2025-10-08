🧱 Proiect Practica 2 — Management Proiecte și Subcontractori
👩‍💻 Autor

Stănciulescu Andreea

📘 Descriere generală

Proiectul ProiectPractica este o aplicație web dezvoltată în ASP.NET Core cu Blazor Server, având ca scop gestionarea proiectelor, subcontractorilor și actelor adiționale.
Aplicația permite adăugarea, afișarea și ștergerea entităților din baza de date, oferind o interfață intuitivă și modernă, bazată pe componente Blazor și un design violet-gradient.

⚙️ Funcționalități principale
1. 🔐 Autentificare utilizatori

Implementată cu ASP.NET Core Identity.

Fiecare utilizator are cont propriu și poate accesa aplicația doar după autentificare.

Afișarea adresei de email a utilizatorului logat în meniul lateral.

2. 🧾 Gestionare subcontractori

Pagina „Listă Subcontractori” permite:

Vizualizarea unei liste de subcontractori existenți (Nume, Domeniu, Email, Telefon).

Adăugarea unui nou subcontractor printr-un formular dedicat.

Ștergerea unui subcontractor din listă cu confirmare.

📸 Exemplu interfață:


3. 📁 Gestionare contracte

Pagina „CONTRACTE” afișează toate contractele asociate proiectelor.

Se pot adăuga și șterge contracte.

Fiecare contract conține:

Valoare totală în RON.

Data semnării și data încheierii.

Legătura către subcontractorul implicat.

🚀 Extinderi Plan de Atac Strategic (Implementate / Propuse)
1. 🧩 Analiză și design entități
Entități noi:

ActAditional

Id, TipAct, DataSemnare, Detalii, ProiectId

Relație: un proiect are mai multe acte adiționale.

TaskProiect

Id, Descriere, Responsabil, Status, Termen, ProiectId

Relație: un proiect are mai multe taskuri.

Relațiile au fost definite prin Foreign Keys (FK) și colecții navigaționale în modelul Proiect.

2. 🖥️ Interfața UI

Au fost adăugate butoane dedicate în pagina proiectului:

„Adaugă Act Adițional” — deschide un formular pentru completarea detaliilor actului.

„Adaugă Task” — formular pentru crearea unui nou task cu detalii și responsabil.

Formularele includ:

Validare a datelor ( câmpuri obligatorii, formate email, lungime minimă text).

Trimiterea datelor către backend prin @onvalidsubmit.

3. 🧠 Logica backend
Pentru Act Adițional:

Salvarea actului în baza de date prin EF Core.

Actualizarea automată a datelor proiectului (ex: valoare, dată finalizare).

Declanșarea de evenimente pentru notificări (UI / email).

Pentru Task Proiect:

Salvare task în baza de date și asociere la proiect.

Marcarea responsabilului.

Generare notificări în UI și pregătire emailuri automate.

4. 🔔 Notificări UI

Implementat mecanism de notificări tip Toast pentru acțiuni reușite (adăugare, ștergere).

Notificările se afișează în colțul ecranului și dispar automat după câteva secunde.

Se poate extinde cu SignalR pentru actualizări în timp real între utilizatori.

5. ✉️ Notificări Email (Propus)

La adăugarea unui task sau act adițional, se trimit emailuri către:

Responsabilul desemnat.

Managerul proiectului.

Template-uri email HTML clare și personalizate.

Serviciu recomandat: SendGrid sau SMTP configurat în appsettings.json.

6. 🧪 Testare și validare

Fluxuri testate complet:

Adăugare subcontractor ✅

Ștergere subcontractor ✅

Validare formular ✅

Salvare date în baza de date ✅

Fluxuri testabile ulterior:

Adăugare Act Adițional.

Adăugare Task Proiect.

Notificări email și toast sincronizate.

7. 📊 Extensii viitoare (pentru versiunea 3)

Istoric modificări proiect prin acte adiționale.

Dashboard notificări cu filtrare.

Reminder email automat pentru taskuri cu termen apropiat.

Export date în format Excel/PDF.

🛠️ Tehnologii folosite

Backend: ASP.NET Core 8.0, Entity Framework Core

Frontend: Blazor Server, Bootstrap, HTML, CSS

Bază de date: SQL Server

Autentificare: ASP.NET Core Identity

Design UI: Paletă violet și alb, componente responsive

🧩 Structura proiectului
📁 ProiectPractica
│
├── 📂 Data
│   ├── ApplicationDbContext.cs
│   └── Migrations/
│
├── 📂 Models
│   ├── Proiect.cs
│   ├── Subcontractor.cs
│   ├── ActAditional.cs
│   └── TaskProiect.cs
│
├── 📂 Pages
│   ├── Subcontractori.razor
│   ├── Contracte.razor
│   └── Proiecte.razor
│
├── 📂 Services
│   ├── EmailService.cs
│   ├── NotificationService.cs
│   └── Repository.cs
│
└── 📄 Program.cs<img width="1920" height="1080" alt="Screenshot (87)" src="https://github.com/user-attachments/assets/b6cbce5e-dd1f-4812-b536-4225e90dfdc4" />


