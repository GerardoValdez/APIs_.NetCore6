using ApiAuto.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAuto.Result.Auto
{
    public class ItemAuto
    {
        public string Modelo { get; set; }
        public string FechaAlta { get; set; }
        public decimal CantidadCombustible { get; set; }
        public string Marca { get; set; }
    }
}
