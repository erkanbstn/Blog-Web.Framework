using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Varliklar.Somut
{
    public class Author
    {
        [Key]
        public int AuthorID { get; set; }
        public string AuthorName { get; set; }
        public string AuthorImage { get; set; }
        public string AuthorAbout { get; set; }
        public string AuthorPassword { get; set; }

        public ICollection<Blog> Blogs { get; set; }
    }
}
