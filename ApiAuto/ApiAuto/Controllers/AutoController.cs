using ApiAuto.Data;
using ApiAuto.Models;
using ApiAuto.Result.Auto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace ApiAuto.Controllers
{
    [ApiController]
    public class AutoController : Controller
    {
        private readonly ContextDB _context;

        public AutoController(ContextDB context)
        {
            _context = context;
        }


        [HttpGet]
        [Route("api/autos")]
        public async Task<ListaItemAutos> getAllAutos()
        {
            var listaItemAutos = new ListaItemAutos();

            var listaAutoBD = await _context.Autos.Include(m => m.Marca).ToListAsync();

            if (listaAutoBD != null)
            {

                foreach (var auto in listaAutoBD)
                {
                    ItemAuto itemAuto = new ItemAuto();

                    itemAuto.Marca = auto.Marca.NombreMarca;
                    itemAuto.Modelo = auto.Modelo;
                    itemAuto.FechaAlta = auto.FechaAlta.ToString();
                    itemAuto.CantidadCombustible = auto.CantidadCombustible;

                    listaItemAutos.ListItemAutos.Add(itemAuto);
                }

                return listaItemAutos;
            }
            else 
            {
                listaItemAutos.setearMensajeError("Error al trae la lista de Autos", HttpStatusCode.InternalServerError);

                return listaItemAutos;
            }
        } 
    }
}
