using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;


namespace MarketIO.Contracts.V1.Requests
{
    public class EditAdminViewModel
    {
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }


        [Required]
        [EmailAddress]
        public string Email { get; set; }

        

    }
}
