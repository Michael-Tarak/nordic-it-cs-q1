using L23_C02_asp_net_core_app_final.Attributes;
using System.ComponentModel.DataAnnotations;

namespace L23_C02_asp_net_core_app_final.Controllers
{
    public class CityUpdateViewModel
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [MaxLength(2048)]
        [DiffentValues(nameof(Name))]
        public string Description { get; set; }

        [Required]
        [Range(1, 200_000_000)]
        public int Population { get; set; }
    }
}