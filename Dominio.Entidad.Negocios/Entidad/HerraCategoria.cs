using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidad.Negocios.Entidad
{
    public class HerraCategoria
    {
        [Display (Name ="Id Herramienta"),Required]       
        public string IdHer { get; set; }
        [Display(Name = "Descripción"), Required] public string DesHer { get; set; }
        [Display(Name = "Medida"), Required] public string MedHer { get; set; }
        [Display(Name = "Categoria"), Required] public string NomCategoria { get; set; }
        
        [Display(Name = "Precio"), Required]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal PreUni { get; set; }

        [Display(Name = "Stock")]
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El stock debe ser mayor que 0.")]
        public int Stock { get; set; }

    }
}
