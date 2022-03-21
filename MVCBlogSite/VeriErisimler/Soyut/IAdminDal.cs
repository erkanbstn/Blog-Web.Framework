using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Varliklar.Somut;
using VeriErisimler.Somut;

namespace VeriErisimler.Soyut
{
    public interface IAdminDal : IGenel<Admin>
    {
        Admin AdminLogin(Admin t);
    }
}
