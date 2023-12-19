using Microsoft.EntityFrameworkCore;
using Model.Entities;

namespace Repository
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Club> Clubs { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.ConfigClub();
            mb.ConfigPlayer();
            mb.ConfigMatch();
            mb.ConfigStadium();
            mb.ConfigTournament();
            mb.ConfigStanding();
            mb.ConfigureStandingClub();
        }

        // Pasos para trabajar con EF + migraciones
        // 1. Agrega un archivo de migración con los cambios pendientes según el snapshot y la configuración en el ApplicationDbContext
        //      Add-Migration {nombre} -StartUpProject NetWebApi -Project Repository -Context ApplicationDbContext
        // 2. Actualizar en la DB las migraciones pendientes (leyendo la tabla _MigrationHistory)
        //      Update-Database -StartUpProject NetWebApi -Project Repository -Context ApplicationDbContext

        // Para eliminar la última migración en el código C#, en la carpeta 'Migrations'
        //      Remove-Migration -StartUpProject NetWebApi -Project Repository -Context ApplicationDbContext

        // Para des-impactar un (o varias) migracion(es) ya impactada(s) en la DB
        //      Update-Database {nombre de la migración en la cual queremos dejar el estado de la DB} -StartUpProject NetWebApi -Project Repository -Context ApplicationDbContext -Migration {nombre}

        // Para hacer un Remove-Migration, no debe estar impactada en la DB
    }
}