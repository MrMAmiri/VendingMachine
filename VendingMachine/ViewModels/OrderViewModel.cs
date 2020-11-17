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
using VendingMachine.Helper;
using VendingMachine.Interfaces;
using VendingMachine.Models;
using Unity;
namespace VendingMachine.ViewModels
{
    public sealed class OrderViewModel : NotifiyPropertyChanged, IOrderView,ICloseable
    {
        public event EventHandler<EventArgs> RequestClose;
        public IBeverageModel BeverageModel { get; set; }
        public RelayCommand BackButtonCommand { get; set; }
        public RelayCommand<IOrderView> CancelButtonCommand { get; set; }
        public BackgroundWorker worker { get; set; }

        private Boolean _canCancel;
        private Boolean _canBack;
        private Style _buttonStyle;

        public OrderViewModel(IBeverageModel model)
        {
            CanCancelOrder = true;
            CanBack = false;
            ButtonStyle = (Style)Application.Current.FindResource("CnlButton");
            BeverageModel = model;
            BeverageModel.ResetMaterials();

            worker = new BackgroundWorker();
            worker.WorkerSupportsCancellation = true;
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.RunWorkerAsync();

            CancelButtonCommand = new RelayCommand<IOrderView>(CancelClick);
            BackButtonCommand = new RelayCommand(BackClick);
        }

        public bool OrderCanceled { get; set; } = false;

        public Boolean CanCancelOrder
        {
            get { return _canCancel; }
            set
            {
                SetProperty(ref _canCancel, value);
            }
        }

        public Boolean CanBack
        {
            get { return _canBack; }
            set
            {
                SetProperty(ref _canBack, value);
            }
        }

        public Style ButtonStyle
        {
            get { return _buttonStyle; }
            set
            {
                SetProperty(ref _buttonStyle, value);
            }
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

        private void CancelClick(IOrderView model)
        {
            model.worker.CancelAsync();
            model.worker.Dispose();
            model.CanBack = true;
            model.CanCancelOrder = false;
            model.OrderCanceled = true;
            model.ButtonStyle = (Style)Application.Current.FindResource("AbrButton");
        }

        public void BackClick()
        {
            MainWindow mainWindow = Helper.ContainerHelper.Container.Resolve<MainWindow>();
            mainWindow.Show();
            RequestClose(null, EventArgs.Empty);
        }


    }
}
