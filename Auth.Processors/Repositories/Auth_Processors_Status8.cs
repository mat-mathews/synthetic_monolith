using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Processors
{
    /// <summary>Defines the possible states for Auth_Processors_Status8.</summary>
    internal enum Auth_Processors_Status8
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