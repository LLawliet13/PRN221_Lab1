using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class MemberRepositoryImpl : IMemberRepository
    {
        private FStoreContext _context;

        public MemberRepositoryImpl(FStoreContext context)
        {
            _context = context;
        }

        public int Create(Member member)
        {
            _context.Add(member);
            return _context.SaveChanges();
        }

        public int Delete(Member member)
        {
            _context.Remove(member);
            return _context.SaveChanges();
        }

        public List<Member> ReadAll()
        {
            return _context.Members.ToList();
        }

        public int Update(int id, Member member)
        {
            member.MemberId = id;
            _context.Update(member);
            return _context.SaveChanges();
        }

     

    }
}
