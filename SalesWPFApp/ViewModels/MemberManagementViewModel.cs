using BusinessObject.Models;
using DataAccess.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using ViewModels;

namespace SalesWPFApp.ViewModels
{
    public class MemberManagementViewModel
    {
        public ICommand searchCommand { get; set; }
        public ICommand createCommand { get; set; }
        public ICommand updateCommand { get; set; }
        public ICommand deleteCommand { get; set; }
        public ObservableCollection<Member> memberList { get; set; }
        public MemberManagement memberManagement;

        public MemberManagementViewModel(MemberManagement memberManagement)
        {
            this.memberManagement = memberManagement;
            memberList = new ObservableCollection<Member>();

            loadMemberList();
            loadCommand();
        }
        public void loadCommand()
        {
            searchCommand = new RelayCommand<Object>(p => true, p =>
            {


            });
            createCommand = new RelayCommand<UIElementCollection>(p => true, p =>
            {
                string email = null;
                string companyName = null;
                string city = null;
                string country = null;
                string password = null;
                Boolean isAllValid = true;
                try
                {
                    foreach (var i in p)
                    {
                        TextBox tb = i as TextBox;
                        if (tb != null)
                        {

                            switch (tb.Name)
                            {
                                case "email":
                                    email = tb.Text;
                                    break;
                                case "companyName":
                                    companyName = tb.Text;
                                    break;
                                case "city":
                                    city = tb.Text;
                                    break;
                                case "country":
                                    country = tb.Text;
                                    break;
                                case "password":
                                    password = tb.Text;
                                    break;
                            }


                        }

                    }
                }
                catch (Exception ex)
                {
                    isAllValid = false;
                }
                if (isAllValid == true)
                {
                    memberManagement.add(new Member(email, companyName, city, country, password));
                    loadMemberList();
                }
                else
                    return;
            });
            updateCommand = new RelayCommand<UIElementCollection>(p => true, p =>
            {
                int MemberId = 0;
                string email = null;
                string companyName = null;
                string city = null;
                string country = null;
                string password = null;
                Boolean isAllValid = true;
                try
                {
                    foreach (var i in p)
                    {
                        TextBox tb = i as TextBox;
                        if (tb != null)
                        {

                            switch (tb.Name)
                            {
                                case "MemberId":
                                    MemberId = Int32.Parse(tb.Text);
                                    break;
                                case "email":
                                    email = tb.Text;
                                    break;
                                case "companyName":
                                    companyName = tb.Text;
                                    break;
                                case "city":
                                    city = tb.Text;
                                    break;
                                case "country":
                                    country = tb.Text;
                                    break;
                                case "password":
                                    password = tb.Text;
                                    break;
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    isAllValid = false;
                }
                if (isAllValid == true)
                {
                    memberManagement.update(MemberId, new Member(email, companyName, city, country, password));
                    loadMemberList();
                }
                else
                    return;
            });
            deleteCommand = new RelayCommand<Object>(p => true, p =>
            {
                Member o = p as Member;
                if (o != null)
                {
                    memberManagement.delete(o);
                    loadMemberList();
                }
                else return;
            });
        }
        public void loadMemberList()
        {
            memberList.Clear();
            List<Member> members = memberManagement.getAll();
            foreach (Member member in members)
                memberList.Add(member);
        }

    }
}
