using Auth.Data135;
using Auth.Models;
using BatchJobs.Mappers;
using DataAccess.Api341;
using Documents.Processors300;
using GalaxyWorks.Handlers385;
using Import.Events374;
using Logging.Mappers157;
using Logging.Service160;
using Notifications.Tests;
using Portal.Core8;
using Portal.Service;
using Scheduling.Validators;
using Security.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Api387;
using Workflow.Data340;

namespace Utilities.Client
{
    /// <summary>Immutable data transfer record for Utilities_Client_Request3.</summary>
    public record Utilities_Client_Request3(string Value, int Count, DateTime Timestamp);

}