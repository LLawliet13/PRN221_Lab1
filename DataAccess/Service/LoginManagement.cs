
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Service
{
    public class LoginManagement : ILoginManagement
    {

        IMemberRepository memberRepository;

        public LoginManagement()
        {
            //IMemberRepository memberRepository
            //this.memberRepository = memberRepository;
        }
        private string author;
        public string authorization()
        {
            return author;
        }

        public Boolean login(string email, string password)
        {
            //List<Member> members = memberRepository.ReadAll();
            //Member foundMember = members.FirstOrDefault(m => m.Email == email && m.Password == password);

            //if (foundMember != null)
            //    return true;
            author = "admin";
            return true;
        }
    }
}
