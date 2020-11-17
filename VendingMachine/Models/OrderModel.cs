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
    public sealed class OrderModel:NotifiyPropertyChanged,IOrderModel
    {
        IBeverageModel _beverage;
        public IBeverageModel Beverage
        {
            get { return _beverage; }
            set
            {
                SetProperty(ref _beverage, value);
            }
        }
    }
}
