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
    public class BeverageModel:NotifiyPropertyChanged, IBeverageModel
    {
        int _beverageId;
        string _beverageName;
        string _beverageImage;
        IList<IIngredientModel> _materials;
        public int BeverageId
        {
            get { return _beverageId; }
            set
            {
                SetProperty(ref _beverageId, value);
            }
        }
        public string BeverageName
        {
            get { return _beverageName; }
            set
            {
                SetProperty(ref _beverageName, value);
            }
        }
        public string BeverageImage
        {
            get { return _beverageImage; }
            set
            {
                SetProperty(ref _beverageImage, value);
            }
        }
        public IList<IIngredientModel> Materials
        {
            get { return _materials; }
            set
            {
                SetProperty(ref _materials, value);
            }
        }
        public void ResetMaterials()
        {
            foreach (var item in Materials)
                item.Status = ReadyStatus.None;
        }

    }
}
