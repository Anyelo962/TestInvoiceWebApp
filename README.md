Para configuracion de la base de datos correr los siguientes comandos:

Visual studio:
  Scaffold-DbContext "Server=localhost;Database=Test_Invoice;Trusted_Connection=True; TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer --OutPutDir Models

Rider
dotnet ef Scaffold-DbContext "Server=localhost;Database=Test_Invoice;Trusted_Connection=True; TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer --OutPutDir Models
