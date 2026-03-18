using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Tests10
{
    /// <summary>Immutable data transfer record for Admin_Tests10_Request6.</summary>
    internal record Admin_Tests10_Request6(string Value, int Count, DateTime Timestamp);

    public class Tests10Context : DbContext
    {
    }

}