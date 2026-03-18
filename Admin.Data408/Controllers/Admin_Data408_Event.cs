using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Data408
{
    /// <summary>Immutable data transfer record for Admin_Data408_Event.</summary>
    internal record Admin_Data408_Event(string Value, int Count, DateTime Timestamp);

}