using ApiEjemplo.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiEjemplo.Data
{
    /*Configuracion inicial, esta clase indica cuales de los modelos que estan en la app
      estan mapeados en la BD (DbSet). Debemos hacer una inyeccion de depen. de esta clase en el program
      para que el controller pueda utilizar context en sus metodos */

    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) :base(options) 
        {
           

        }


        public DbSet<Persona> Persona { get; set;} //uno por cada modelo
        public DbSet<Deporte> Deporte {get; set;}
    }
}
