using System.ComponentModel.DataAnnotations;

namespace jobconnect.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Tài khoản hoặc Email không được trống.")]
        public string UserNameOrEmail { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được trống.")]
        public string Password { get; set; }

    }
}
