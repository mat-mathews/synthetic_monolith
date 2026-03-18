using Admin.Shared310;
using Admin.Web;
using Billing.Mappers124;
using Billing.Tests;
using DataAccess.Validators;
using Documents.Service;
using Import.Api272;
using Import.Client65;
using Integration.Api469;
using Logging.Data;
using Logging.Validators;
using Notifications.Shared380;
using Notifications.Tests;
using Reporting.Tests67;
using Security.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Contracts434;

namespace Billing.Shared
{
    /// <summary>Immutable data transfer record for Billing_Shared_ViewModel12.</summary>
    internal record Billing_Shared_ViewModel12(string Value, int Count, DateTime Timestamp);

}