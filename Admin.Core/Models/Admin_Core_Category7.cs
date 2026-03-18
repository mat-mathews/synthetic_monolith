using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Core
{
    /// <summary>Defines the possible states for Admin_Core_Category7.</summary>
    internal enum Admin_Core_Category7
    {
        None = 0,
        Active = 1,
        Inactive = 2,
        Pending = 3,
        Processing = 4,
        Completed = 5,
        Failed = 6,
    }

    public class CoreContext : DbContext
    {
    }

}