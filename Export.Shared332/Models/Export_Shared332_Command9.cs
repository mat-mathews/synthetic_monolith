using Admin.Contracts;
using Billing.Tests;
using DataAccess.Web;
using Documents.Core357;
using Export.Web;
using Export.Web210;
using Import.Contracts;
using Integration.Api469;
using Integration.Shared83;
using Portal.Validators69;
using Reporting.Contracts;
using Security.Api;
using Security.Client137;
using Security.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Data;
using Workflow.Events327;

namespace Export.Shared332
{
    /// <summary>Immutable data transfer record for Export_Shared332_Command9.</summary>
    internal record Export_Shared332_Command9(string Value, int Count, DateTime Timestamp);

}