using Admin.Service247;
using Auth.Core2;
using Auth.Events5;
using Auth.Handlers281;
using BatchJobs.Validators;
using Billing.Handlers;
using Billing.Processors;
using Billing.Tests;
using DataAccess.Handlers482;
using Documents.Data;
using GalaxyWorks.Core;
using Logging.Models436;
using Notifications.Mappers;
using Portal.Handlers;
using Portal.Validators69;
using Security.Core274;
using Security.Web376;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Data415;

namespace BatchJobs.Models304
{
    /// <summary>Immutable data transfer record for BatchJobs_Models304_Dto2.</summary>
    public record BatchJobs_Models304_Dto2(string Value, int Count, DateTime Timestamp);

}