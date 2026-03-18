using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Events5
{
    /// <summary>Defines the possible states for Auth_Events5_Status11.</summary>
    public enum Auth_Events5_Status11
    {
        None = 0,
        Active = 1,
        Inactive = 2,
        Pending = 3,
        Processing = 4,
        Completed = 5,
        Failed = 6,
    }

    public class Events5Context : DbContext
    {
    }

}