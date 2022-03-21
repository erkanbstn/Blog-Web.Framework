using Islemler.Soyut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Varliklar.Somut;
using VeriErisimler.Soyut;

namespace Islemler.Somut
{
    public class CommentManager:ICommentService
    {
        public static int blogid = 0;
        ICommentDal _CommentDal;
        public CommentManager(ICommentDal CommentDal)
        {
            _CommentDal = CommentDal;
        }
        public void ServisEkle(Comment t)
        {
            _CommentDal.Ekle(t);
        }

        public void ServisGuncelle(Comment t)
        {
            _CommentDal.Guncelle(t);
        }

        public List<Comment> ServisIDListele(int id)
        {
            return _CommentDal.IDListele(b => b.CommentID == id);
        }

        public List<Comment> ServisListele()
        {
            return _CommentDal.Listele();
        }

        public void ServisSil(Comment t)
        {
            _CommentDal.Sil(t);
        }
        public List<Comment> CommmentBlog(int id)
        {
            return _CommentDal.IDListele(b => b.BlogID == id);
        }
        public Comment ServisIDGetir(int id)
        {
            return _CommentDal.IDBul(b => b.CommentID == id);
        }

    }
}
