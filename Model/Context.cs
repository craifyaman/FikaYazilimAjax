using Microsoft.EntityFrameworkCore;

namespace Fika.Model
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=Mehmet; Database=FikaYazilim; integrated security=true;");
        }

        public DbSet<Personel> Personels { get; set; }
        public DbSet<Musteri> Musteris { get; set; }
        public DbSet<Grup> Grups { get; set; }
        public DbSet<Stok> Stoks { get; set; }
        public DbSet<SatisHareket> SatisHarekets { get; set; }
    }
}
