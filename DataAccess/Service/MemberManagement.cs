using BusinessObject.Models;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Service
{
    public class MemberManagement
    {
        IMemberRepository MemberRepository;

        public MemberManagement(IMemberRepository memberRepository)
        {
            MemberRepository = memberRepository;
        }

        public Member viewInfo(int id)
        {
            return null;
        }
        public int delete(Member Member)
        {
            return MemberRepository.Delete(Member);
        }
        public int update(int id, Member Member)
        {
            return MemberRepository.Update(id, Member);
        }
        public List<Member> getAll()
        {
            return MemberRepository.ReadAll();
        }
        public int add(Member Member)
        {
            return MemberRepository.Create(Member);
        }

    }
}
