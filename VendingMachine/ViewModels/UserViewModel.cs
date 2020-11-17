using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VendingMachine.Interfaces;
using VendingMachine.Models;

namespace VendingMachine.ViewModels
{
    public sealed class UserViewModel : IUserViewModel
    {
        public UserViewModel()
        {
            Users = new List<IUserModel>
            {
                new UserModel()
                {
                    UserId =1,
                    UserName ="Elliot A.",
                    UserAvatar ="assets/ell.png"
                },
                new UserModel()
                {
                    UserId =2,
                    UserName ="Sarahmorphy",
                    UserAvatar ="assets/sarah.png"
                },
                new UserModel()
                {
                    UserId =3,
                    UserName ="Ipinlnd",
                    UserAvatar ="assets/ipin.png"
                }
            };

            LoggedInUser= Users.FirstOrDefault(s => s.UserId == 2);
        }
        public IUserModel LoggedInUser { get; set; }
        public IList<IUserModel> Users { get; }

    }
}
