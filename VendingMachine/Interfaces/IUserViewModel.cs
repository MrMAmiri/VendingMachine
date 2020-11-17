using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Interfaces
{
    public interface IUserViewModel
    {
         IUserModel LoggedInUser { get; set; }

         IList<IUserModel> Users { get; }

    }
}
