using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using VendingMachine.Interfaces;
using VendingMachine.Models;
using VendingMachine.ViewModels;

namespace VendingMachine.Helper
{
    public static class ContainerHelper
    {
        private static IUnityContainer _container;
        static ContainerHelper()
        {
            _container = new UnityContainer();
            _container.RegisterType<IBeverageModel, BeverageModel>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IIngredientModel, IngredientModel>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IOrderView, OrderViewModel>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IBeverageViewModel, BeverageViewModel>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IUserModel, UserModel>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IUserViewModel, UserViewModel>(new ContainerControlledLifetimeManager());
        }

        public static IUnityContainer Container
        {
            get { return _container; }
        }
    }
}
