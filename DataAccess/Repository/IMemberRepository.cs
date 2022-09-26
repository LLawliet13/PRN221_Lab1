using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IMemberRepository
    {
        public int Create(Member member);
        public int Update(int id, Member member);
        public int Delete(Member member);
        public List<Member> ReadAll();
    }
}
