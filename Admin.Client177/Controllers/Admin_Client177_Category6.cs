using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Client177
{
    /// <summary>Defines the possible states for Admin_Client177_Category6.</summary>
    public enum Admin_Client177_Category6
    {
        None = 0,
        Active = 1,
        Inactive = 2,
        Pending = 3,
        Processing = 4,
        Completed = 5,
        Failed = 6,
    }

    public class Client177Context : DbContext
    {
    }

}