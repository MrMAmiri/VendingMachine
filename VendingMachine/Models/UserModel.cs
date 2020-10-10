using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Models
{
    public sealed class UserModel : AppModel, INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Members  

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        int _userId;
        string _userName;
        string _userAvatar;

        public int UserId
        {
            get { return _userId; }
            set
            {
                _userId = value;
                OnPropertyChanged("UserId");
            }
        }

        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                OnPropertyChanged("UserName");
            }
        }

        public string UserAvatar
        {
            get { return _userAvatar; }
            set
            {
                _userAvatar = value;
                OnPropertyChanged("UserAvatar");
            }
        }
    }
}
