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
            Member oldMember = _context.Members.Where(o => o.MemberId == id).FirstOrDefault();
            oldMember.MemberId = id;
            oldMember.Email = member.Email;
            oldMember.CompanyName = member.CompanyName;
            oldMember.City = member.City;
            oldMember.Country = member.Country;
            oldMember.Password = member.Password;
            _context.Update(oldMember);
            return _context.SaveChanges();
        }



    }
}
