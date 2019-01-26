using System.ComponentModel.DataAnnotations;

namespace Domain.AppUser.Model
{

    public class AplicationUserModel
    {
        [Required(ErrorMessage = "Username is required")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}