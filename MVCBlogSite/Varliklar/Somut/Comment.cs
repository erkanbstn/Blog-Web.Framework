using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Varliklar.Somut
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }
        public string UserName { get; set; }
        public string Mail { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentDate { get; set; }
        public int BlogID { get; set; }
        public virtual Blog Blogs { get; set; }
    }
}
