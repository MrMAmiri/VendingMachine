using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Helper;
using VendingMachine.Interfaces;

namespace VendingMachine.Models
{
    public sealed class UserModel : NotifiyPropertyChanged, IUserModel, IAppModel
    {

        int _userId;
        string _userName;
        string _userAvatar;
        string _appTitle;

        public UserModel()
        {
            AppTitle = "E-Corp Vending Machine";
        }
        public string AppTitle
        {
            get { return _appTitle; }
            set
            {
                SetProperty(ref _appTitle, value);
            }
        }

        public int UserId
        {
            get { return _userId; }
            set
            {
                SetProperty(ref _userId, value);
            }
        }

        public string UserName
        {
            get { return _userName; }
            set
            {
                SetProperty(ref _userName, value);
            }
        }

        public string UserAvatar
        {
            get { return _userAvatar; }
            set
            {
                SetProperty(ref _userAvatar, value);
            }
        }
    }
}
