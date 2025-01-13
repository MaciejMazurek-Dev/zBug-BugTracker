using System.ComponentModel.DataAnnotations;

namespace BugTracker.BlazorUI.Models.Authentication
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "First name is required.")]
        [MaxLength(20)]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last name is required.")]
        [MaxLength(20)]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{6,}$",
            ErrorMessage = "Password must be at least 6 characters long, contain an uppercase letter, a lowercase letter, a digit, and a special character.")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Repeat password is required.")]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
