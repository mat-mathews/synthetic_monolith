using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Web46
{
    /// <summary>Immutable data transfer record for Admin_Web46_ViewModel9.</summary>
    public record Admin_Web46_ViewModel9(string Value, int Count, DateTime Timestamp);

    public class Web46Context : DbContext
    {
    }

}