using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Shared310
{
    /// <summary>Immutable data transfer record for Admin_Shared310_Dto9.</summary>
    public record Admin_Shared310_Dto9(string Value, int Count, DateTime Timestamp);

    public class Shared310Context : DbContext
    {
    }

}