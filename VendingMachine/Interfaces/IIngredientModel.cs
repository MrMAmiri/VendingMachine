using FontAwesome.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Models;

namespace VendingMachine.Interfaces
{
    public interface IIngredientModel
    {
        int Priority { get; set; }

        int MatId { get; set; }

        string MatName { get; set; }

        /// <summary>
        /// In Second
        /// </summary>
        short TimeToReady { get; set; }

        FontAwesomeIcon Image { get; set; }

        ReadyStatus Status { get; set; }

        bool ImgSpin { get; set; }
    }
}
