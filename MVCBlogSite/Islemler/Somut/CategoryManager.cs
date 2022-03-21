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
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public void ServisEkle(Category t)
        {
            _categoryDal.Ekle(t);
        }

        public void ServisGuncelle(Category t)
        {
            _categoryDal.Guncelle(t);
        }

        //public Category ServisIDGetir(Expression<Func<Category, bool>> filter)
        //{
        //    return _categoryDal.IDBul(filter);
        //}

        public Category ServisIDGetir(int id)
        {
            return _categoryDal.IDBul(b => b.CategoryID == id);
        }

        public List<Category> ServisIDListele(int id)
        {
            return _categoryDal.IDListele(b => b.CategoryID == id);
        }

        public List<Category> ServisListele()
        {
            return _categoryDal.Listele();
        }

        public void ServisSil(Category t)
        {
            _categoryDal.Sil(t);
        }
    }
}
