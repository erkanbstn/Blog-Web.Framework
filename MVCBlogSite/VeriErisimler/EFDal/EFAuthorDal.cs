using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Varliklar.Somut;
using VeriErisimler.Somut;
using VeriErisimler.Soyut;

namespace VeriErisimler.EFDal
{
    public class EFAuthorDal : GenelDepo<Author>, IAuthorDal
    {
        public Author AuthorSign(Author a)
        {
            using (var x = new VeriTabani())
            {
                return x.Authors.FirstOrDefault(b => b.AuthorName == a.AuthorName && b.AuthorPassword == a.AuthorPassword);
            }

        }
    }
}
