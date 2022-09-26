using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Member
    {
        public Member()
        {
            Orders = new HashSet<Order>();
        }

        public int MemberId { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Password { get; set; }

        public Member(string email, string companyName, string city, string country, string password, ICollection<Order> orders)
        {
            Email = email;
            CompanyName = companyName;
            City = city;
            Country = country;
            Password = password;
            Orders = orders;
        }

        public Member(int memberId, string email, string companyName, string city, string country, string password, ICollection<Order> orders)
        {
            MemberId = memberId;
            Email = email;
            CompanyName = companyName;
            City = city;
            Country = country;
            Password = password;
            Orders = orders;
        }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
