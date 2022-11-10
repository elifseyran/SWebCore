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
        public string? CompanyName { get; set; }
        public string? Position { get; set; }
        public DateTime? StartingDate { get; set; }
        public DateTime? EndDate { get; set; }  
        public string? CompanySector { get; set; }  
        public string? BusinessArea { get; set; }

    }
}
