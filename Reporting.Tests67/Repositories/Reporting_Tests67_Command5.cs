using Admin.Tests10;
using Auth.Api116;
using Auth.Client249;
using Billing.Api;
using Billing.Events;
using Billing.Service432;
using DataAccess.Models;
using Imaging.Tests;
using Integration.Processors241;
using Logging.Data;
using Portal.Data;
using Reporting.Api;
using Reporting.Client;
using Reporting.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Contracts;
using Workflow.Mappers;

namespace Reporting.Tests67
{
    /// <summary>Immutable data transfer record for Reporting_Tests67_Command5.</summary>
    internal record Reporting_Tests67_Command5(string Value, int Count, DateTime Timestamp);

}