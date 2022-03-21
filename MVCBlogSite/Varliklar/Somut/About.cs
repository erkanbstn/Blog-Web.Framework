using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Varliklar.Somut
{
    public class About
    {
        [Key]
        public int AboutID { get; set; }
        public string AboutContent { get; set; }
        public string AboutContent2 { get; set; }
        public string AboutImage1 { get; set; }
        public string AboutImage2 { get; set; }
    }
}
