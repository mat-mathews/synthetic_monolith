using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Handlers
{
    /// <summary>Defines the possible states for Admin_Handlers_State9.</summary>
    public enum Admin_Handlers_State9
    {
        None = 0,
        Active = 1,
        Inactive = 2,
        Pending = 3,
        Processing = 4,
        Completed = 5,
        Failed = 6,
    }

    public class HandlersContext : DbContext
    {
    }

}