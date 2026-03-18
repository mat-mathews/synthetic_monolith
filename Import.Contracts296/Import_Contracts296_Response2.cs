using Admin.Data117;
using Admin.Data465;
using Auth.Web70;
using BatchJobs.Contracts;
using Billing.Processors103;
using Documents.Service215;
using Export.Web210;
using GalaxyWorks.Core309;
using Imaging.Data;
using Logging.Validators359;
using Notifications.Models;
using Portal.Data266;
using Reporting.Processors;
using Scheduling.Processors397;
using Scheduling.Web60;
using Security.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Mappers;

namespace Import.Contracts296
{
    /// <summary>Immutable data transfer record for Import_Contracts296_Response2.</summary>
    public record Import_Contracts296_Response2(string Value, int Count, DateTime Timestamp);

}