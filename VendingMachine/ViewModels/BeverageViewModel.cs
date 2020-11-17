using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using VendingMachine.Helper;
using VendingMachine.Interfaces;
using VendingMachine.Models;
using Unity;
using Unity.Resolution;

namespace VendingMachine.ViewModels
{
    public sealed class BeverageViewModel : NotifiyPropertyChanged, IBeverageViewModel, ICloseable
    {

        public event EventHandler<EventArgs> RequestClose;
        public IList<IBeverageModel> Beverages { get; }
        public RelayCommand<IBeverageModel> BeverageSelectCommand { get; set; }
        public BeverageViewModel()
        {
            var ingVM = ContainerHelper.Container.Resolve<IngredientViewModel>();

            Beverages = new List<IBeverageModel>
            {
                new BeverageModel()
                {
                    BeverageId =1,
                    BeverageName ="Hot Chocolate",
                    BeverageImage ="assets/hot_chocolate.jpg",
                    Materials=ingVM.Ingredients.Where
                    (
                        d=> (new[]{1,2,3}).Contains(d.MatId)
                    ).ToList()
                },
                new BeverageModel()
                {
                    BeverageId =2,
                    BeverageName ="Coffee",
                    BeverageImage ="assets/white_coffee.jpg",
                    Materials=ingVM.Ingredients.Where
                    (
                        d=> (new[]{1,4,5,3,6}).Contains(d.MatId)
                    ).ToList()
                },
                new BeverageModel()
                {
                    BeverageId =3,
                    BeverageName ="Iced Coffee",
                    BeverageImage ="assets/iced_coffee.jpg",
                    Materials=ingVM.Ingredients.Where
                    (
                        d=> (new[]{1,3,7,8}).Contains(d.MatId)
                    ).ToList()
                },
                new BeverageModel()
                {
                    BeverageId =4,
                    BeverageName ="Lemon Tea",
                    BeverageImage ="assets/lemon_tea.jpg",
                    Materials=ingVM.Ingredients.Where
                    (
                        d=> (new[]{9,10,11,12,13}).Contains(d.MatId)
                    ).ToList()
                }

            };

            BeverageSelectCommand = new RelayCommand<IBeverageModel>(BeverageSelected);
        }
        public void BeverageSelected(IBeverageModel bvModel)
        {

            var orderViewModel = ContainerHelper.Container.Resolve<OrderViewModel>(new ResolverOverride[]
                               {
                                       new ParameterOverride("model", bvModel)
                               });

            Order order = ContainerHelper.Container.Resolve<Order>(new ResolverOverride[]
                               {
                                       new ParameterOverride("viewModel", orderViewModel)
                               });
            order.Show();

            RequestClose(this, EventArgs.Empty);


        }


    }
}
