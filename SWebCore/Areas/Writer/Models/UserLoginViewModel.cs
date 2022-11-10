using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace SWebCore.Areas.Writer.Models
{
    public class UserLoginViewModel
    {
        [Display(Name="Kullanıcı Adı")]
        [Required(ErrorMessage ="Kullanıcı Adını giriniz...!")]
        public string UserName { get; set; }

        [Display(Name ="Şifre")]
        [Required(ErrorMessage ="Şifreyi giriniz...!")]
        public string Password { get; set; }    
    }
}
