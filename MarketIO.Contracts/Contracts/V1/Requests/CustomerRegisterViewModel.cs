using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarketIO.Contracts.V1.Requests
{
    public class CustomerRegisterViewModel : RegisterViewModel
    {
        [Required(ErrorMessage = "Street is Required.")]
        public string Street { get; set; }
        [Required(ErrorMessage = "City is Required.")]
        public string City { get; set; }
        [Required(ErrorMessage = "State is Required.")]
        public string State { get; set; }

        [Display(Name = "Zip Code")]
        [StringLength(10, MinimumLength = 5)]
        [RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "Invalid Zip")]
        [Required(ErrorMessage = "Zip Code is Required.")]
        public string Zip_Code { get; set; }

    }
}
