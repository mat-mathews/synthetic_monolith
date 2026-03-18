using Admin.Models;
using Admin.Web;
using Auth.Api;
using Billing.Processors259;
using Common.Processors245;
using Common.Shared297;
using DataAccess.Api;
using Documents.Mappers;
using Documents.Validators;
using Export.Models262;
using GalaxyWorks.Tests;
using Import.Api272;
using Import.Api314;
using Integration.Shared;
using Notifications.Models466;
using Reporting.Events;
using Reporting.Tests67;
using Scheduling.Models260;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Tests
{
    /// <summary>Immutable data transfer record for Auth_Tests_Response1.</summary>
    public record Auth_Tests_Response1(string Value, int Count, DateTime Timestamp);

    public class TestsContext : DbContext
    {
    }

}