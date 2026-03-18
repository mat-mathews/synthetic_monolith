using Admin.Events;
using Admin.Service456;
using Admin.Validators;
using Auth.Contracts402;
using Auth.Handlers281;
using Common.Web;
using DataAccess.Api307;
using DataAccess.Data;
using DataAccess.Handlers482;
using Export.Models;
using GalaxyWorks.Events77;
using Imaging.Service;
using Import.Validators;
using Notifications.Validators252;
using Portal.Tests;
using Scheduling.Contracts425;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Processors;
using Workflow.Client47;

namespace BatchJobs.Validators
{
    /// <summary>Immutable data transfer record for BatchJobs_Validators_Command2.</summary>
    internal record BatchJobs_Validators_Command2(string Value, int Count, DateTime Timestamp);

    public class ValidatorsContext : DbContext
    {
    }

}