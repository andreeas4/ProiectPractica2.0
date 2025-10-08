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
<img width="1920" height="1080" alt="Screenshot (86)" src="https://github.com/user-attachments/assets/4c2ab8d0-3cac-4f3d-838a-d88c26848748" />
<img width="1920" height="1080" alt="Screenshot (85)" src="https://github.com/user-attachments/assets/af48af5b-48e3-4ab3-beb8-d61a3c8c9e5e" />
<img width="1920" height="1080" alt="Screenshot (84)" src="https://github.com/user-attachments/assets/2a7603eb-dd83-4e10-9baa-53175b60acff" />
<img width="1920" height="1080" alt="Screenshot (83)" src="https://github.com/user-attachments/assets/85baef4e-8f02-46b0-8c98-ec5ed7d93953" />
<img width="1920" height="1080" alt="Screenshot (82)" src="https://github.com/user-attachments/assets/11ad28c1-999f-4baa-ac24-c5ff0c6af251" />
<img width="1920" height="1080" alt="Screenshot (81)" src="https://github.com/user-attachments/assets/450ea12d-7a0c-436d-919d-9730b54329b9" />
<img width="1920" height="1080" alt="Screenshot (80)" src="https://github.com/user-attachments/assets/f2642e25-45a2-4956-bca3-0f8666556e98" />
<img width="1920" height="1080" alt="Screenshot (79)" src="https://github.com/user-attachments/assets/979fa7c3-cc1c-4901-9cda-dae2e4e8b981" />
<img width="1920" height="1080" alt="Screenshot (78)" src="https://github.com/user-attachments/assets/566c2c53-9ea1-4433-b819-4c358c88b047" />
<img width="1920" height="1080" alt="Screenshot (77)" src="https://github.com/user-attachments/assets/5839468c-878a-4e69-948d-b2afe0186396" />
<img width="1920" height="1080" alt="Screenshot (76)" src="https://github.com/user-attachments/assets/257a749a-db03-416c-9757-84c0b2ee023d" />
<img width="1920" height="1080" alt="Screenshot (75)" src="https://github.com/user-attachments/assets/67da5b61-86a6-4033-80f2-cbc7c136ddb7" />

