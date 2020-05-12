using System.ComponentModel.DataAnnotations;


namespace MarketIO.Contracts.V1.Requests
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare(nameof(Password) , ErrorMessage ="The confirmed Password doesn't match the password") ]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

    }
}
