using Admin.Validators;
using Auth.Handlers209;
using Auth.Processors400;
using Common.Data21;
using GalaxyWorks.Core309;
using Imaging.Events416;
using Integration.Core;
using Integration.Service147;
using Logging.Models436;
using Portal.Mappers233;
using Portal.Web494;
using Reporting.Web105;
using Scheduling.Mappers442;
using Security.Contracts238;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Api387;
using Utilities.Mappers;
using Workflow.Core;
using Workflow.Web;

namespace GalaxyWorks.Web
{
    /// <summary>Immutable data transfer record for GalaxyWorks_Web_Request4.</summary>
    internal record GalaxyWorks_Web_Request4(string Value, int Count, DateTime Timestamp);

}