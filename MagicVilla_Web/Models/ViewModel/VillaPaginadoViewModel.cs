using MagicVilla_Web.Models.Dto;

namespace MagicVilla_Web.Models.ViewModel
{
    public class VillaPaginadoViewModel
    {
        // Para manejo de páginados
        public int PageNumber { get; set; }

        public int TotalPaginas { get; set; }

        public string Previo { get; set; } = "disabled";

        public string Siguiente { get; set; } = "";

        public IEnumerable<VillaDto> VillaList { get; set; } //Toda la lista numerada
    }
}
