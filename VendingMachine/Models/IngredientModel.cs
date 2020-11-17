using FontAwesome.WPF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Threading;
using VendingMachine.Helper;
using VendingMachine.Interfaces;

namespace VendingMachine.Models
{
    public sealed class IngredientModel: NotifiyPropertyChanged, IIngredientModel
    {

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
                SetProperty(ref _matId, value);
            }
        }

        public string MatName
        {
            get { return _matName; }
            set
            {
                SetProperty(ref _matName, value);
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
                SetProperty(ref _timeToReady, value);
            }
        }

        public FontAwesomeIcon Image
        {
            get { return _image; }
            set
            {
                SetProperty(ref _image, value);
            }
        }

        public ReadyStatus Status
        {
            get { return _status; }
            set
            {
              
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

                SetProperty(ref _status, value);
            }
        }

        public bool ImgSpin
        {
            get { return _imgSpin; }
            set
            {
                SetProperty(ref _imgSpin, value);
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
