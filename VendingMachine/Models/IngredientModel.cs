using FontAwesome.WPF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Threading;

namespace VendingMachine.Models
{
    public sealed class IngredientModel: INotifyPropertyChanged
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

        public IngredientModel()
        {
            Image = FontAwesomeIcon.CircleOutline;
            ImgSpin = false;
        }

        int _matId;
        string _matName;
        short _timeToReady;
        ReadyStatus _status=ReadyStatus.None;
        FontAwesomeIcon _image;
        bool _imgSpin;

        public int Priority { get; set; }

        public int MatId
        {
            get { return _matId; }
            set
            {
                _matId = value;
                OnPropertyChanged("MatId");
            }
        }

        public string MatName
        {
            get { return _matName; }
            set
            {
                _matName = value;
                OnPropertyChanged("MatName");
            }
        }

        /// <summary>
        /// In Second
        /// </summary>
        public short TimeToReady
        {
            get { return _timeToReady; }
            set
            {
                _timeToReady = value;
                OnPropertyChanged("TimeToReady");
            }
        }

        public FontAwesomeIcon Image
        {
            get { return _image; }
            set
            {
                _image = value;
                OnPropertyChanged("Image");
            }
        }

        public ReadyStatus Status
        {
            get { return _status; }
            set
            {
                _status = value;
                switch (_status)
                {
                    case ReadyStatus.None:

                        Dispatcher.CurrentDispatcher.Invoke(() => Image= FontAwesomeIcon.CircleOutline);
                        ImgSpin = false;
                        break;
                    case ReadyStatus.Doing:

                        Dispatcher.CurrentDispatcher.Invoke(() => Image= FontAwesomeIcon.Refresh);
                        ImgSpin = true;
                        break;
                    case ReadyStatus.Ready:

                        Dispatcher.CurrentDispatcher.Invoke(() => Image= FontAwesomeIcon.Check);
                        ImgSpin = false;
                        break;
                }

                OnPropertyChanged("Status");
            }
        }

        public bool ImgSpin
        {
            get { return _imgSpin; }
            set
            {
                _imgSpin = value;
                OnPropertyChanged("ImgSpin");
            }
        }

    }

    public enum ReadyStatus
    {
        None=1,
        Doing=2,
        Ready=3
    }
}
