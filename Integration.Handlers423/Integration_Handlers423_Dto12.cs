using Admin.Handlers450;
using Admin.Processors35;
using Auth.Mappers206;
using Billing.Mappers225;
using DataAccess.Contracts;
using DataAccess.Contracts404;
using GalaxyWorks.Events256;
using GalaxyWorks.Validators355;
using Import.Client7;
using Import.Mappers;
using Logging.Contracts74;
using Logging.Core159;
using Portal.Contracts;
using Reporting.Processors;
using Security.Processors246;
using Security.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Mappers232;

namespace Integration.Handlers423
{
    /// <summary>Immutable data transfer record for Integration_Handlers423_Dto12.</summary>
    public record Integration_Handlers423_Dto12(string Value, int Count, DateTime Timestamp);

}