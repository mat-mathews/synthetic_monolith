using Admin.Data;
using Admin.Shared;
using Admin.Validators240;
using Billing.Client22;
using Documents.Core357;
using Documents.Data419;
using Documents.Service215;
using Export.Client;
using Import.Client356;
using Integration.Processors;
using Portal.Service489;
using Portal.Validators250;
using Reporting.Contracts;
using Reporting.Processors;
using Reporting.Shared;
using Reporting.Tests67;
using Security.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Data340;

namespace Export.Core
{
    /// <summary>Immutable data transfer record for Export_Core_Command2.</summary>
    public record Export_Core_Command2(string Value, int Count, DateTime Timestamp);

}