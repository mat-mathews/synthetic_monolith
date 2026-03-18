using Admin.Data117;
using Admin.Processors;
using Auth.Core2;
using BatchJobs.Shared;
using Billing.Handlers122;
using Documents.Validators;
using Export.Processors111;
using GalaxyWorks.Mappers318;
using GalaxyWorks.Service;
using GalaxyWorks.Web;
using Notifications.Web308;
using Portal.Events139;
using Reporting.Api;
using Reporting.Models;
using Security.Data;
using Security.Processors246;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Data415;

namespace Import.Api179
{
    /// <summary>Immutable data transfer record for Import_Api179_Request.</summary>
    internal record Import_Api179_Request(string Value, int Count, DateTime Timestamp);

}