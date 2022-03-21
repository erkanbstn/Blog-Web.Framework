using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Varliklar.Somut;
using VeriErisimler.Somut;
using VeriErisimler.Soyut;

namespace VeriErisimler.EFDal
{
    public class EFAdminDal : GenelDepo<Admin>, IAdminDal
    {
        public Admin AdminLogin(Admin t)
        {
            using (var c = new VeriTabani())
            {
                return c.Admins.FirstOrDefault(b => b.UserName == t.UserName && b.Password == t.Password);
            }
        }
    }
}
