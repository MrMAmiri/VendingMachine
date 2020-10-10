using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Models
{
    public class BeverageModel: INotifyPropertyChanged
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

        int _beverageId;
        string _beverageName;
        string _beverageImage;
        IList<IngredientModel> _materials;

        public int BeverageId
        {
            get { return _beverageId; }
            set
            {
                _beverageId = value;
                OnPropertyChanged("BeverageId");
            }
        }

        public string BeverageName
        {
            get { return _beverageName; }
            set
            {
                _beverageName = value;
                OnPropertyChanged("BeverageName");
            }
        }

        public string BeverageImage
        {
            get { return _beverageImage; }
            set
            {
                _beverageImage = value;
                OnPropertyChanged("BeverageImage");
            }
        }

        public IList<IngredientModel> Materials
        {
            get { return _materials; }
            set
            {
                _materials = value;
                OnPropertyChanged("Materials");
            }
        }

        public void ResetMaterials()
        {
            foreach (var item in Materials)
                item.Status = ReadyStatus.None;
        }
    }
}
