using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAuto.Models
{
    [Table("Marcas")]
    public class Marca
    {
        public int Id { get; set; }
        public string NombreMarca { get; set; }

    }
}
