using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using VendingMachine.Models;

namespace VendingMachine.ViewModels
{
    public sealed class OrderViewModel : INotifyPropertyChanged
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
        public BeverageModel BeverageModel { get; set; }

        private readonly BackgroundWorker worker = new BackgroundWorker();
        private Boolean _canCancel;
        private Boolean _canBack;
        private Style _buttonStyle;

        public bool OrderCanceled { get; set; } = false;

        public Boolean CanCancelOrder
        {
            get { return _canCancel; }
            set
            {
                _canCancel = value;
                OnPropertyChanged("CanCancelOrder");
            }
        }

        public Boolean CanBack
        {
            get { return _canBack; }
            set
            {
                _canBack = value;
                OnPropertyChanged("CanBack");
            }
        }

        public Style ButtonStyle
        {
            get { return _buttonStyle; }
            set
            {
                _buttonStyle = value;
                OnPropertyChanged("ButtonStyle");
            }
        }


        public OrderViewModel(BeverageModel model)
        {
            CanCancelOrder = true;
            CanBack = false;

            ButtonStyle = (Style)Application.Current.FindResource("CnlButton");

            BeverageModel = model;
            BeverageModel.ResetMaterials();

            worker.WorkerSupportsCancellation = true;
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.RunWorkerAsync();
        }
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            foreach (var item in BeverageModel.Materials)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    return;
                }

                item.Status = ReadyStatus.Doing;
                Thread.Sleep(item.TimeToReady * 1000);
                item.Status = ReadyStatus.Ready;
            }
        }

        private void worker_RunWorkerCompleted(object sender,
                                                   RunWorkerCompletedEventArgs e)
        {
            if(!OrderCanceled)
            {
                CanCancelOrder = false;
                CanBack = true;
                ButtonStyle = (Style)Application.Current.FindResource("ComButton");
            }

        }



        private ICommand mBackButton;
        public ICommand BackButtonCommand
        {
            get
            {
                if (mBackButton == null)
                    mBackButton = new BackButton();
                return mBackButton;
            }
            set
            {
                mBackButton = value;
            }
        }

        private class BackButton : ICommand
        {
            #region ICommand Members  

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();

                ((Window)parameter).Close();

            }

            #endregion
        }





        private ICommand mCancelButtonCommand;
        public ICommand CancelButtonCommand
        {
            get
            {
                if (mCancelButtonCommand == null)
                    mCancelButtonCommand = new CancelButton(this);
                return mCancelButtonCommand;
            }
            set
            {
                mCancelButtonCommand = value;
            }
        }

        private class CancelButton : ICommand
        {
            #region ICommand Members  

            OrderViewModel VModel;

            public CancelButton(OrderViewModel model)
            {
                VModel = model;
            }

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
                VModel.worker.CancelAsync();
                VModel.worker.Dispose();
                VModel.CanBack = true;
                VModel.CanCancelOrder = false;
                VModel.OrderCanceled = true;
                VModel.ButtonStyle = (Style)Application.Current.FindResource("AbrButton");
            }

            #endregion
        }


    }
}
