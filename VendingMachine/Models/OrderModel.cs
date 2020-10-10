using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Models
{
    public sealed class OrderModel: INotifyPropertyChanged
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

        BeverageModel _beverage;

        public BeverageModel Beverage
        {
            get { return _beverage; }
            set
            {
                _beverage = value;
                OnPropertyChanged("Beverage");
            }
        }
    }
}
