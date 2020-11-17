using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Interfaces
{
    public interface IUserModel
    {
        int UserId { get; set; }

        string UserName { get; set; }

        string UserAvatar { get; set; }
    }
}
