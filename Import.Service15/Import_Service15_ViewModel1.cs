using Admin.Client346;
using Admin.Service364;
using Admin.Shared363;
using Auth.Client38;
using Auth.Tests498;
using Billing.Api;
using Common.Service;
using Documents.Data484;
using Export.Shared145;
using Import.Client7;
using Import.Processors472;
using Notifications.Processors20;
using Reporting.Shared394;
using Security.Web230;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Mappers;
using Workflow.Api;

namespace Import.Service15
{
    /// <summary>Immutable data transfer record for Import_Service15_ViewModel1.</summary>
    public record Import_Service15_ViewModel1(string Value, int Count, DateTime Timestamp);

}