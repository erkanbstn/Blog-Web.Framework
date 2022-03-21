using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace VeriErisimler.Soyut
{
    public interface IGenel<T>
    {
        List<T> Listele();
        void Ekle(T t);
        void Sil(T t);
        void Guncelle(T t);
        T IDBul(Expression<Func<T, bool>> where);
        List<T> IDListele(Expression<Func<T, bool>> filter);
    }
}
