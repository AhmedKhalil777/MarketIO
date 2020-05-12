using System.ComponentModel.DataAnnotations;


namespace MarketIO.Contracts.V1.Requests
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name ="Remember Me")]
        public bool RemmemberMe { get; set; }


    }
}
