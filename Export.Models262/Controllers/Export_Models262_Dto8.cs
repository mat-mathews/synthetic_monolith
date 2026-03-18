using Admin.Core;
using Admin.Processors35;
using Admin.Service456;
using Auth.Shared;
using Common.Data126;
using Common.Events;
using DataAccess.Handlers482;
using DataAccess.Validators88;
using Documents.Api129;
using Documents.Service;
using Documents.Validators102;
using Logging.Mappers;
using Portal.Events;
using Portal.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Contracts24;
using Utilities.Service358;
using Workflow.Tests222;

namespace Export.Models262
{
    /// <summary>Immutable data transfer record for Export_Models262_Dto8.</summary>
    public record Export_Models262_Dto8(string Value, int Count, DateTime Timestamp);

}