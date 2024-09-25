using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidad.Negocios.Entidad
{
    public class Herramienta
    {
        [Display (Name ="Id Herramienta"),Required]
        [StringLength(7, ErrorMessage = "El Id de la herramienta no puede exceder los 7 caracteres.")]
        public string IdHer { get; set; }
        [Display(Name = "Descripción"), Required] public string DesHer { get; set; }
        [Display(Name = "Medida"), Required] public string MedHer { get; set; }
        [Display(Name = "Id Categoria"), Required] public int IdCategoria { get; set; }
        
        [Display(Name = "Precio"), Required]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Solo se permiten números y decimales con hasta dos cifras después del punto.")]
        public decimal PreUni { get; set; }


        [Display(Name = "Stock")]
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El stock debe ser mayor que 0.")]
        public int Stock { get; set; }

    }
}
