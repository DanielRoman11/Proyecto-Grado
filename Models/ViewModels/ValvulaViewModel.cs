using System.ComponentModel.DataAnnotations;

namespace ValveSizing.Models.ViewModels
{
    public class ValvulaViewModel
    {
        public DateTime? FechaCreacion { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public float Caudal { get; set; }
        [Required]
        public int Diametro { get; set; }

    }
}
