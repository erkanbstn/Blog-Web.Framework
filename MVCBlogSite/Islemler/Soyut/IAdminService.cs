using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Varliklar.Somut;

namespace Islemler.Soyut
{
    public interface IAdminService:IGenelService<Admin>
    {
        Admin AdminLogin(Admin t);
    }
}
