using BusinessObject.Models;
using DataAccess.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesWPFApp.ViewModels
{
    public class MemberManagementViewModel
    {
        ObservableCollection<Member> members { get; set; }
        MemberManagement memberManagement;

        public MemberManagementViewModel(MemberManagement memberManagement)
        {
            this.memberManagement = memberManagement;
        }


    }
}
