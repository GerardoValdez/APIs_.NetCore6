using ApiEjemplo.Data;
using ApiEjemplo.Resultados;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiEjemplo.Controllers
{
    [ApiController]
    public class PersonaController : Controller
    {
        private readonly Context _context;
        public PersonaController(Context context)
        {
             _context = context; //context lo recibe de la config del program cuando inicia la app
        }

        [HttpGet]
        [Route("api/Personas/getPrimerPersona")]
        public async Task<ActionResult<PersonaResultado>> getPersonaUnica()
        {
            var resultado = await _context.Persona.FirstOrDefaultAsync(p => p.Apellido.Equals("Valdez") && p.Nombre.Contains("G"));
            return Ok(resultado); 
        }

        [HttpGet]
        [Route("api/Personas/getPersonas")]
        public async Task<ActionResult<List<PersonaResultado>>> getPersonas()
        {
            var resultado = await _context.Persona.ToListAsync();

            return Ok(resultado);
        }
    }
}
