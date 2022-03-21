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
    public class AuthorManager : IAuthorService
    {
        IAuthorDal _AuthorDal;
        public AuthorManager(IAuthorDal AuthorDal)
        {
            _AuthorDal = AuthorDal;
        }

        public Author AuthorSign(Author a)
        {
            return _AuthorDal.AuthorSign(a);
        }

        public void ServisEkle(Author t)
        {
            _AuthorDal.Ekle(t);
        }

        public void ServisGuncelle(Author t)
        {
            _AuthorDal.Guncelle(t);
        }

        //public Author ServisIDGetir(Expression<Func<Author, bool>> filter)
        //{
        //    return _AuthorDal.IDBul(filter);
        //}

        public Author ServisIDGetir(int id)
        {
            return _AuthorDal.IDBul(b => b.AuthorID == id);
        }

        public List<Author> ServisIDListele(int id)
        {
            return _AuthorDal.IDListele(b => b.AuthorID == id);
        }

        public List<Author> ServisListele()
        {
            return _AuthorDal.Listele();
        }

        public void ServisSil(Author t)
        {
            _AuthorDal.Sil(t);
        }
    }
}
