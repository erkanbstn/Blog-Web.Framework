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
    public class BlogManager : IBlogService
    {
        IBlogDal _blogDal;
        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }
        public void ServisEkle(Blog t)
        {
            _blogDal.Ekle(t);
        }

        public void ServisGuncelle(Blog t)
        {
            _blogDal.Guncelle(t);
        }

        public List<Blog> ServisIDListele(int id)
        {
            return _blogDal.IDListele(b => b.BlogID == id);
        }

        public List<Blog> ServisListele()
        {
            return _blogDal.Listele();
        }

        public void ServisSil(Blog t)
        {
            _blogDal.Sil(t);
        }

        public string BlogTitle(int id)
        {
            var posttitle = ServisListele().OrderByDescending(b => b.CategoryID).Where(b => b.CategoryID == id).Select(b => b.BlogTitle).FirstOrDefault();
            return posttitle;
        }
        public string BlogDate(int id)
        {
            var posttitle = ServisListele().OrderByDescending(b=>b.CategoryID).Where(b => b.CategoryID == id).Select(b => b.BlogDate).FirstOrDefault();
            return posttitle.ToString("dd/MMMM/yyyy");
        }
        public string BlogImage(int id)
        {
            var posttitle = ServisListele().OrderByDescending(b => b.CategoryID).Where(b => b.CategoryID == id).Select(b => b.BlogImage).FirstOrDefault();
            return posttitle;
        }

        public int BlogAuthor(int id)
        {
            return ServisListele().Where(b => b.BlogID == id).Select(b => b.AuthorID).FirstOrDefault();
        }

        public List<Blog> AuthorBlogs(int id)
        {
            return ServisListele().Where(b => b.AuthorID == id).ToList();
        }

        public List<Blog> CategoryBlogs(int id)
        {
            return ServisListele().Where(b => b.CategoryID == id).ToList();
        }

        //public Blog ServisIDGetir(Expression<Func<Blog, bool>> filter)
        //{
        //    return _blogDal.IDBul(filter);
        //}

        public Blog ServisIDGetir(int id)
        {
            return _blogDal.IDBul(b=>b.BlogID==id);
        }
    }
}
