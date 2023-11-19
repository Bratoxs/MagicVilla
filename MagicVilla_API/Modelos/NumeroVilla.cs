using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagicVilla_API.Modelos
{
    public class NumeroVilla
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)] //El ingreso del Id va hacer de forma manual
        public int VillaNo { get; set; }

        [Required]
        public int VillaId { get; set; } //Id de la tabla Villas

        [ForeignKey("VillaId")]
        public Villa Villa { get; set; } //Relacion foreignKey tabla Villas

        public string DetalleEspecial { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime FechaActualizacion { get; set; }

    }
}
