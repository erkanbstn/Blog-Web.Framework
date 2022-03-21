using Islemler.Soyut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Varliklar.Somut;
using VeriErisimler.Soyut;

namespace Islemler.Somut
{
    public class AdminManager : IAdminService

    {
        IAdminDal _AdminDal;

        public AdminManager(IAdminDal AdminDal)
        {
            _AdminDal = AdminDal;
        }

        public Admin AdminLogin(Admin t)
        {
            return _AdminDal.AdminLogin(t);
        }

        public void ServisEkle(Admin t)
        {
            _AdminDal.Ekle(t);
        }

        public void ServisGuncelle(Admin t)
        {
            _AdminDal.Guncelle(t);
        }

        public Admin ServisIDGetir(int id)
        {
            return _AdminDal.IDBul(b => b.AdminID == id);
        }

        public List<Admin> ServisIDListele(int id)
        {
            return _AdminDal.IDListele(b => b.AdminID == id);
        }

        public List<Admin> ServisListele()
        {
            return _AdminDal.Listele();
        }

        public void ServisSil(Admin t)
        {
            _AdminDal.Sil(t);
        }

    }
}
