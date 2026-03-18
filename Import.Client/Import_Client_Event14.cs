using Admin.Models476;
using Admin.Shared14;
using Admin.Validators240;
using Auth.Core140;
using BatchJobs.Api501;
using BatchJobs.Processors500;
using DataAccess.Validators88;
using Documents.Service215;
using Export.Handlers;
using Integration.Contracts290;
using Logging.Models379;
using Notifications.Data348;
using Portal.Events139;
using Portal.Processors;
using Portal.Shared;
using Scheduling.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Contracts192;

namespace Import.Client
{
    /// <summary>Immutable data transfer record for Import_Client_Event14.</summary>
    internal record Import_Client_Event14(string Value, int Count, DateTime Timestamp);

}