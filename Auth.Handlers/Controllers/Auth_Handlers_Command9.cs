using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Handlers
{
    /// <summary>Immutable data transfer record for Auth_Handlers_Command9.</summary>
    internal record Auth_Handlers_Command9(string Value, int Count, DateTime Timestamp);

    public class HandlersContext : DbContext
    {
    }

}