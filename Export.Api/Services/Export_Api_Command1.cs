using Admin.Api255;
using Admin.Client177;
using Admin.Core121;
using Admin.Data;
using Admin.Web4;
using Auth.Contracts;
using Documents.Web164;
using Export.Data;
using Export.Data150;
using GalaxyWorks.Service;
using Imaging.Models459;
using Integration.Service107;
using Logging.Events;
using Logging.Handlers455;
using Portal.Models413;
using Scheduling.Models441;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Api66;
using Workflow.Web;

namespace Export.Api
{
    /// <summary>Immutable data transfer record for Export_Api_Command1.</summary>
    public record Export_Api_Command1(string Value, int Count, DateTime Timestamp);

}