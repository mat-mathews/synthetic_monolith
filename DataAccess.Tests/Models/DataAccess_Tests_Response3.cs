using Auth.Contracts395;
using Auth.Tests;
using BatchJobs.Models;
using BatchJobs.Service;
using DataAccess.Data;
using Export.Tests62;
using GalaxyWorks.Data224;
using Imaging.Events303;
using Integration.Client;
using Logging.Web;
using Notifications.Tests195;
using Portal.Contracts170;
using Portal.Service;
using Reporting.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Models;
using Workflow.Tests75;

namespace DataAccess.Tests
{
    /// <summary>Immutable data transfer record for DataAccess_Tests_Response3.</summary>
    public record DataAccess_Tests_Response3(string Value, int Count, DateTime Timestamp);

}