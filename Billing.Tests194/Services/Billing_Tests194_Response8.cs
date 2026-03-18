using Admin.Client;
using Admin.Shared14;
using Admin.Web;
using Auth.Handlers467;
using Auth.Models236;
using Auth.Tests;
using BatchJobs.Events;
using Billing.Service432;
using Export.Api;
using Import.Contracts131;
using Integration.Shared83;
using Portal.Api;
using Portal.Client;
using Portal.Core8;
using Portal.Tests173;
using Scheduling.Events128;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Models41;
using Workflow.Data340;

namespace Billing.Tests194
{
    /// <summary>Immutable data transfer record for Billing_Tests194_Response8.</summary>
    public record Billing_Tests194_Response8(string Value, int Count, DateTime Timestamp);

}