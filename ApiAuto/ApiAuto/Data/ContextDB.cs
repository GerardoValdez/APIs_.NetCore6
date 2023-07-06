using ApiAuto.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiAuto.Data
{
    public class ContextDB : DbContext
    {
        public ContextDB(DbContextOptions<ContextDB> options) : base(options){ }


        public DbSet<Auto> Autos { get; set; }
        public DbSet<Marca> Marcas { get; set; }

    }
}
