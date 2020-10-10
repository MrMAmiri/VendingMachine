using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Models
{
    public abstract class AppModel
    {
        public string AppTitle { get; set; }

        public AppModel()
        {
            AppTitle = "E-Corp Vending Machine";
        }
    }
}
