using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Contracts
{
    /// <summary>Defines the possible states for Admin_Contracts_Level10.</summary>
    internal enum Admin_Contracts_Level10
    {
        None = 0,
        Active = 1,
        Inactive = 2,
        Pending = 3,
        Processing = 4,
        Completed = 5,
        Failed = 6,
    }

}