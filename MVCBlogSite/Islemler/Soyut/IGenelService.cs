using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Islemler.Soyut
{
    public interface IGenelService<T>
    {
        void ServisEkle(T t);
        void ServisSil(T t);
        void ServisGuncelle(T t);
        List<T> ServisListele();
        List<T> ServisIDListele(int id);
        T ServisIDGetir(int id);
    }
}
