using Admin.Data408;
using Auth.Core;
using Auth.Mappers208;
using Billing.Mappers198;
using Common.Core;
using DataAccess.Tests;
using Export.Mappers;
using GalaxyWorks.Web;
using Imaging.Data;
using Imaging.Models;
using Import.Mappers56;
using Notifications.Tests299;
using Portal.Handlers;
using Portal.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Client;
using Workflow.Models;
using Workflow.Validators;

namespace Logging.Processors
{
    /// <summary>Immutable data transfer record for Logging_Processors_Dto1.</summary>
    public record Logging_Processors_Dto1(string Value, int Count, DateTime Timestamp);

}