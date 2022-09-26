using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Service
{
    public interface ILoginManagement
    {
       
        public Boolean login(string email, string password);
        public string authorization();
    }
}
