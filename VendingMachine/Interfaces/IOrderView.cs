using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using VendingMachine.Helper;

namespace VendingMachine.Interfaces
{
    public interface IOrderView
    {
        BackgroundWorker worker { get; set; }
        IBeverageModel BeverageModel { get; set; }
        bool OrderCanceled { get; set; }
        Boolean CanCancelOrder { get; set; }
        Boolean CanBack { get; set; }
        Style ButtonStyle { get; set; }
        RelayCommand BackButtonCommand { get; set; }
        RelayCommand<IOrderView> CancelButtonCommand { get; set; }
    }
}
