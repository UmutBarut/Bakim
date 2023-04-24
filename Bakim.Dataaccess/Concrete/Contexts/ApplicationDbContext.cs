
using Bakim.Entity;
using Bakim.Entity.Views;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakim.Dataaccess.Concrete.Contexts
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Section> Sections { get; set; }
        public DbSet<RoutineBakim> RoutineBakimlar { get; set; }
        public DbSet<SectionFault> SectionFaults { get; set; }
        public DbSet<WorkTaskUser> WorkTaskUsers { get; set; }
        public DbSet<WorkTaskTransfer> WorkTaskTransfers { get; set; }
        public DbSet<WorkTask> WorkTasks { get; set; }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<Call> Calls { get; set; }
        public DbSet<ProductionSection> ProductionSections { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<UserAnnouncement> UserAnnouncements { get; set; }
        public DbSet<Corporation> Corporations { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<StockGroup> StockGroups { get; set; }
        public DbSet<VarlikGroup> VarlikGroups { get; set; }
        public DbSet<Calendar> Calendars { get; set; }
        public DbSet<RoutineBakimMakine> routineBakimMakines { get; set; }
        public DbSet<RoutineBakimTuru> routinebakimturu { get; set;}
        public DbSet<DetayGroup> DetayGrubu { get; set; }
        public DbSet<StokKategori> StokKategorisi { get; set; }
        public DbSet<TedarikciFirma> tedarikciFirmalar { get; set;}
        public DbSet<Varlik> varlik { get; set; }
        public DbSet<Stok_Firma> Stok_Firmas { get; set; }
        public DbSet<Birim> Birimler { get; set; }
        public DbSet<Talep> Talepler { get; set; }
        public DbSet<atanankullanicilar> atanankullanicilars { get; set; }
        public DbSet<Task_Stock> Task_Stock { get; set; }
        public DbSet<Marka> markalar { get; set; }
        public DbSet<MarkaGrup> markaGrup { get; set; }
        public DbSet<MarkaKalem> markaKalem { get; set; }
        public DbSet<RutinBakimKategorisi> RutinBakimKategori { get; set; }
        public DbSet<RutinBakim> RutinBakim { get; set; }
        public DbSet<RutinBakim_Stock> RutinBakim_Stock { get; set; }
        public DbSet<SectionFaultCategory> SectionFaultCategories { get; set; }
        

        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            MySqlServerVersion version = new MySqlServerVersion(new Version(5, 7, 30));
            optionsBuilder.UseMySql("Server=localhost;Port=3306;Database=Bakim.db;Uid=root;Pwd=Umut2003;", version);
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=factory;Trusted_Connection=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

           modelBuilder.Entity<atanankullanicilar>().HasNoKey().ToView("atanankullanicilar");

            base.OnModelCreating(modelBuilder);
        }
    }
}
