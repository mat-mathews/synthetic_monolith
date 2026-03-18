using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Models
{
    /// <summary>Immutable data transfer record for Auth_Models_Event.</summary>
    public record Auth_Models_Event(string Value, int Count, DateTime Timestamp);

}