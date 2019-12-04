using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CityApp.ViewModels
{
    public class CreateCityViewModel
    {
        [Required(ErrorMessage = "Имя города не указано")]
        [MaxLength(256)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Описание не указано")]
        [MaxLength(1024)]
        [Compare(nameof(Name))]
        public string Descryption { get; set; }

        [Required(ErrorMessage = "Количество не указано")]
        [Range(minimum: 0, maximum: 120_000_000)]
        public int Population { get; set ; }
    }
}
