using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Models;

namespace VendingMachine.ViewModels
{
    public sealed class IngredientViewModel
    {
        public IList<IngredientModel> Ingredients { get; }

        public IngredientViewModel()
        {
            Ingredients = new List<IngredientModel>
            {
                new IngredientModel(){MatId=1,MatName="Boil Water",TimeToReady=4},
                new IngredientModel(){MatId=2,MatName="Add drinking chocolate to cup",TimeToReady=5},
                new IngredientModel(){MatId=3,MatName="Add Water",TimeToReady=4},
                new IngredientModel(){MatId=4,MatName="Add sugar",TimeToReady=5},
                new IngredientModel(){MatId=5,MatName="Add coffee granules to cup",TimeToReady=7},
                new IngredientModel(){MatId=6,MatName="Add milk",TimeToReady=5},
                new IngredientModel(){MatId=7,MatName="Steep tea bag in hot water",TimeToReady=5},
                new IngredientModel(){MatId=8,MatName="Add lemon",TimeToReady=5},
                new IngredientModel(){MatId=9,MatName="Crush Ice",TimeToReady=7},
                new IngredientModel(){MatId=10,MatName="Add ice to blender",TimeToReady=6},
                new IngredientModel(){MatId=11,MatName="Add coffee syrup to blender",TimeToReady=4},
                new IngredientModel(){MatId=12,MatName="Blend ingredients",TimeToReady=3},
                new IngredientModel(){MatId=13,MatName="Add ingredients",TimeToReady=6},
            };
        }
    }
}
