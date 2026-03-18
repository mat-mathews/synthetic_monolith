using Admin.Processors;
using Auth.Handlers467;
using Auth.Mappers28;
using Auth.Models236;
using Documents.Validators;
using Documents.Web;
using GalaxyWorks.Contracts392;
using Imaging.Tests328;
using Imaging.Web172;
using Import.Service496;
using Integration.Handlers;
using Notifications.Events42;
using Portal.Processors52;
using Scheduling.Core;
using Security.Events288;
using Security.Models18;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Data340;
using Workflow.Web;

namespace Reporting.Client
{
    /// <summary>Immutable data transfer record for Reporting_Client_Request9.</summary>
    public record Reporting_Client_Request9(string Value, int Count, DateTime Timestamp);

}