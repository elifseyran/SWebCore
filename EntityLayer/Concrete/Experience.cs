using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    //deneyimleri
    public class Experience
    {
        [Key]
        public int ExperienceID { get; set; }
        [Required(ErrorMessage = "boş bırakılamaz")]
        public string? CompanyName { get; set; }
        [Required(ErrorMessage = "boş bırakılamaz")]
        public string? Position { get; set; }
        [Required(ErrorMessage = "boş bırakılamaz")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.YYYY}", ApplyFormatInEditMode = true)]
        public DateTime? StartingDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.YYYY}", ApplyFormatInEditMode = true)]
        public DateTime? EndDate { get; set; }
        [Required(ErrorMessage = "boş bırakılamaz")]
        public string? CompanySector { get; set; }
        [Required(ErrorMessage = "boş bırakılamaz")]
        public string? BusinessArea { get; set; }

    }
}
