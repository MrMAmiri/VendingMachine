using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using VendingMachine.Models;

namespace VendingMachine.ViewModels
{
    public sealed class BeverageViewModel
    {
        public Window Holder { get; set; }
        public IList<BeverageModel> Beverages { get; }

        public BeverageViewModel()
        {
            var ingVM = new IngredientViewModel();

            Beverages = new List<BeverageModel>
            {
                new BeverageModel(){BeverageId=1,BeverageName="Hot Chocolate",
                                    BeverageImage ="assets/hot_chocolate.jpg",
                                    Materials=ingVM.Ingredients.Where(d=> (new[]{1,2,3}).Contains(d.MatId)).ToList()
                },
                new BeverageModel(){BeverageId=2,BeverageName="Coffee",
                                    BeverageImage ="assets/white_coffee.jpg",
                                     Materials=ingVM.Ingredients.Where(d=> (new[]{1,4,5,3,6}).Contains(d.MatId)).ToList()
                },
                new BeverageModel(){BeverageId=3,BeverageName="Iced Coffee",
                                    BeverageImage ="assets/iced_coffee.jpg",
                                     Materials=ingVM.Ingredients.Where(d=> (new[]{1,3,7,8}).Contains(d.MatId)).ToList()
                },
                new BeverageModel(){BeverageId=4,BeverageName="Lemon Tea",
                                    BeverageImage ="assets/lemon_tea.jpg",
                                     Materials=ingVM.Ingredients.Where(d=> (new[]{9,10,11,12,13}).Contains(d.MatId)).ToList()
                }

            };
        }




        private ICommand mBeverageSelect;
        public ICommand BeverageSelectCommand
        {
            get
            {
                if (mBeverageSelect == null)
                    mBeverageSelect = new BeverageSelect(Holder);
                return mBeverageSelect;
            }
            set
            {
                mBeverageSelect = value;
            }
        }

        private class BeverageSelect : ICommand
        {
            #region ICommand Members  

            Window holdr;

            public BeverageSelect(Window hold)
            {
                holdr = hold;
            }
            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
                Order order = new Order();
                order.DataContext = new OrderViewModel((BeverageModel)parameter);
                order.Show();
                holdr.Close();
            }

            #endregion
        }




    }
}
