using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Client
{
    /// <summary>Immutable data transfer record for Admin_Client_ViewModel7.</summary>
    public record Admin_Client_ViewModel7(string Value, int Count, DateTime Timestamp);

    public class ClientContext : DbContext
    {
    }

}