using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VendingMachine.Models;

namespace VendingMachine.ViewModels
{
    public sealed class UserViewModel
    {
        public UserViewModel()
        {
            Users = new List<UserModel>
            {
                new UserModel(){UserId=1,UserName="Elliot A.",UserAvatar="assets/ell.png"},
                new UserModel(){UserId=2,UserName="Sarahmorphy",UserAvatar="assets/sarah.png"},
                new UserModel(){UserId=3,UserName="Ipinlnd",UserAvatar="assets/ipin.png"}
            };
        }

        public UserModel LoggedInUser { get; set; }

        public IList<UserModel> Users { get; }

    }
}
