using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Portfolio
    {
        [Key]
        public int PortfolioID { get; set; }
        [Required(ErrorMessage = "Başlık alanı boş bırakılamaz")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Açıklama boş bırakılamaz")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "Görsel boş geçilemez boş bırakılamaz")]
        public string? ImageUrl { get; set; }
        public string? ProjectUrl { get; set; }
  
    }
}
