using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    //Kişinin yetenekleri
    public class Skill
    {
        [Key]
        public int SkillID { get; set; }


        [Required(ErrorMessage = "Başlık boş bırakılamaz")]
        public string? Title { get; set; }


        [Required(ErrorMessage = "Değer boş bırakılamaz")]
        public int? Value { get; set; }
    }
}
