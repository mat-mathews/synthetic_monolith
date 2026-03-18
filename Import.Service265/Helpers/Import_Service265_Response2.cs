using Auth.Contracts;
using Auth.Core2;
using Auth.Events5;
using Auth.Events78;
using BatchJobs.Events435;
using BatchJobs.Mappers362;
using Billing.Processors103;
using Common.Client53;
using DataAccess.Api341;
using DataAccess.Api454;
using Imaging.Shared115;
using Notifications.Api144;
using Scheduling.Models441;
using Security.Shared365;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Api66;
using Utilities.Models;

namespace Import.Service265
{
    /// <summary>Immutable data transfer record for Import_Service265_Response2.</summary>
    internal record Import_Service265_Response2(string Value, int Count, DateTime Timestamp);

}