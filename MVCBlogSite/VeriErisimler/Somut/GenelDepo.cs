using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VeriErisimler.Soyut;

namespace VeriErisimler.Somut
{
    public class GenelDepo<T> : IGenel<T> where T : class
    {

        VeriTabani v = new VeriTabani();
        DbSet<T> _obje;

        public GenelDepo()
        {
            _obje = v.Set<T>();
        }

        public void Ekle(T t)
        {
            var eklenen = v.Entry(t);
            eklenen.State = EntityState.Added;
            v.SaveChanges();
        }

        public void Guncelle(T t)
        {
            var guncellenen = v.Entry(t);
            guncellenen.State = EntityState.Modified;
            v.SaveChanges();
        }

        public T IDBul(Expression<Func<T, bool>> where)
        {
            return _obje.FirstOrDefault(where);
        }

        public List<T> IDListele(Expression<Func<T, bool>> filter)
        {
            return _obje.Where(filter).ToList();
        }

        public List<T> Listele()
        {
            return _obje.ToList();
        }

        public void Sil(T t)
        {
            var silinen = v.Entry(t);
            silinen.State = EntityState.Deleted;
            v.SaveChanges();
        }
    }
}
