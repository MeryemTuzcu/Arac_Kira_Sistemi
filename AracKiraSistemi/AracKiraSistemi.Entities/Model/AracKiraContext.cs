using AracKiraSistemi.Entities.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracKiraSistemi.Entities.Model
{
    public class AracKiraContext : DbContext
    {
        public AracKiraContext() : base("name=AracKiraEntities")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ArabaMap());
            modelBuilder.Configurations.Add(new KiraTuruMap());
            modelBuilder.Configurations.Add(new MusteriMap());
            modelBuilder.Configurations.Add(new SepetMap());
        }

        public DbSet<Araba> Araba { get; set; }
        public DbSet<KiraTuru> KiraTuru { get; set; }
        public DbSet<Musteri> Musteri { get; set; }
        public DbSet<Sepet> Sepet { get; set; }
    }
}
