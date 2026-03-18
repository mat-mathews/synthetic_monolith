using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Shared
{
    /// <summary>Defines the possible states for Admin_Shared_Mode7.</summary>
    internal enum Admin_Shared_Mode7
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