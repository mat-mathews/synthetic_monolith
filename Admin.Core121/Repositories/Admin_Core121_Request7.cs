using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Core121
{
    /// <summary>Immutable data transfer record for Admin_Core121_Request7.</summary>
    internal record Admin_Core121_Request7(string Value, int Count, DateTime Timestamp);

    public class Core121Context : DbContext
    {
    }

}