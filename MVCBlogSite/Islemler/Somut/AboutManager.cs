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
    public class AboutManager : IAboutService
    {
        IAboutDal _AboutDal;

        public AboutManager(IAboutDal AboutDal)
        {
            _AboutDal = AboutDal;
        }
        public void ServisEkle(About t)
        {
            _AboutDal.Ekle(t);
        }

        public void ServisGuncelle(About t)
        {
            _AboutDal.Guncelle(t);
        }

        //public About ServisIDGetir(Expression<Func<About, bool>> filter)
        //{
        //    return _AboutDal.IDBul(filter);
        //}

        public About ServisIDGetir(int id)
        {
            return _AboutDal.IDBul(b=>b.AboutID==id);
        }

        public List<About> ServisIDListele(int id)
        {
            return _AboutDal.IDListele(b => b.AboutID == id);
        }

        public List<About> ServisListele()
        {
            return _AboutDal.Listele();
        }

        public void ServisSil(About t)
        {
            _AboutDal.Sil(t);
        }
    }
}
