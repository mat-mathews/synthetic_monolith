using Admin.Models;
using Admin.Service;
using Admin.Service456;
using DataAccess.Data;
using Documents.Data;
using Documents.Tests;
using Import.Api272;
using Import.Contracts180;
using Import.Service;
using Integration.Contracts290;
using Integration.Events;
using Logging.Events;
using Notifications.Core;
using Reporting.Contracts371;
using Scheduling.Processors335;
using Security.Api134;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logging.Validators
{
    /// <summary>Immutable data transfer record for Logging_Validators_ViewModel10.</summary>
    internal record Logging_Validators_ViewModel10(string Value, int Count, DateTime Timestamp);

    public class ValidatorsContext : DbContext
    {
    }

}