using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Models;

namespace VendingMachine.Interfaces
{
    public interface IBeverageModel
    {
        int BeverageId { get; set; }

        string BeverageName { get; set; }

        string BeverageImage { get; set; }

        IList<IIngredientModel> Materials { get; set; }

        void ResetMaterials();

    }
}
