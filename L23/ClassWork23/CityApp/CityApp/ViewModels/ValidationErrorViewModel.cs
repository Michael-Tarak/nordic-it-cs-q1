using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CityApp.ViewModels
{
    public class ValidationErrorViewModel
    {
        public string  Property { get; set; }
        public string[] Errors { get; set; }
        public ValidationErrorViewModel(
            string property,
            ModelStateEntry entry)
        {
            Property = property;
            Errors = entry.Errors.Select(error => error.ErrorMessage).ToArray();
        }
    }
}
