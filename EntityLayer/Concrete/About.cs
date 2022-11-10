using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    //bu sınıfta kişihakkında bilgi
    //Veri tabanındaki tablolarımızı temsil eden bir varlık
    public class About
    {
        [Key]
        public int AboutID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? Age { get; set; }
        public string? Mail { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? ImageUrl { get; set; }
    }
}
