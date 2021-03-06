﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using VendingMachine.Helper;
using Unity;
using Unity.Lifetime;
using VendingMachine.ViewModels;

namespace VendingMachine
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MainWindow mainWindow = ContainerHelper.Container.Resolve<MainWindow>(); // Creating Main window
            mainWindow.Show();
        }
    }
}
