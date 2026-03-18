using Admin.Handlers447;
using Admin.Shared310;
using Auth.Shared325;
using Billing.Validators;
using Common.Api213;
using Common.Data;
using Common.Processors245;
using Export.Web229;
using GalaxyWorks.Processors;
using GalaxyWorks.Web;
using Import.Client64;
using Import.Mappers56;
using Integration.Processors;
using Logging.Client405;
using Logging.Shared;
using Portal.Processors389;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Export.Shared
{
    /// <summary>Immutable data transfer record for Export_Shared_Request4.</summary>
    internal record Export_Shared_Request4(string Value, int Count, DateTime Timestamp);

}