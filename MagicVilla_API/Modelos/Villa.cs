using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagicVilla_API.Modelos
{
    public class Villa
    {
        [Key] //Se indica que este campo va hacer nuestra clave primaria
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Id se incrementará de uno en uno automaticamente
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Detalle { get; set; }

        [Required] 
        public double Tarifa { get; set; }

        public int Ocupantes { get; set; }

        public int MetrosCuadrados { get; set; }

        public string ImagenUrl { get; set; }

        public string Amenidad { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime fechaActualizacion { get; set; }
    }
}
