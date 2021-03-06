﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VendingMachine.Helper;

namespace VendingMachine.Interfaces
{
    public interface IBeverageViewModel
    {
        IList<IBeverageModel> Beverages { get; }
        RelayCommand<IBeverageModel> BeverageSelectCommand { get; set; }
    }
}
