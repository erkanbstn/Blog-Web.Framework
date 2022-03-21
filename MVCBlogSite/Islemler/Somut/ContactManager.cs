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
    public class ContactManager : IContactService
    {
        IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }
        public void ServisEkle(Contact t)
        {
            _contactDal.Ekle(t);
        }

        public void ServisGuncelle(Contact t)
        {
            _contactDal.Guncelle(t);
        }

        //public Contact ServisIDGetir(Expression<Func<Contact, bool>> filter)
        //{
        //    return _contactDal.IDBul(filter);
        //}

        public Contact ServisIDGetir(int id)
        {
            return _contactDal.IDBul(b => b.ContactID == id);
        }

        public List<Contact> ServisIDListele(int id)
        {
            return _contactDal.IDListele(b => b.ContactID == id);
        }

        public List<Contact> ServisListele()
        {
            return _contactDal.Listele();
        }

        public void ServisSil(Contact t)
        {
            _contactDal.Sil(t);
        }
    }
}
