using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAuto.Models
{
    [Table("Autos")]
    public class Auto
    {
        public int Id { get; set; }
        public string Modelo { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaModificacion { get; set; } //el ? indica a la app que puede ser null la prop
        public decimal CantidadCombustible { get; set; }
        public int IdMarca { get; set; }

        [ForeignKey("IdMarca")]
        public Marca Marca { get; set; }

        /*En el código que proporcionaste, la propiedad IdMarca en la clase Auto representa la clave foránea
          que establece una relación con la clase Marca. Esta propiedad se utiliza para almacenar el valor de la
          clave primaria de la tabla Marca que está asociada a un determinado auto.
          La anotación [ForeignKey("IdMarca")] se utiliza para indicar que la propiedad Marca en la clase Auto
          es una clave foránea que hace referencia a la propiedad IdMarca en la clase Marca. Esto establece la 
          relación entre las dos clases en la base de datos.*/
    }
}
