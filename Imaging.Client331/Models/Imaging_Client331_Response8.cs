using Admin.Events;
using Admin.Mappers324;
using Auth.Client;
using Auth.Mappers28;
using BatchJobs.Client109;
using Billing.Shared312;
using DataAccess.Contracts404;
using DataAccess.Shared;
using Export.Web130;
using Imaging.Events416;
using Imaging.Mappers;
using Import.Service15;
using Import.Service291;
using Integration.Handlers244;
using Integration.Web;
using Portal.Mappers;
using Portal.Validators125;
using Reporting.Api393;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imaging.Client331
{
    /// <summary>Immutable data transfer record for Imaging_Client331_Response8.</summary>
    internal record Imaging_Client331_Response8(string Value, int Count, DateTime Timestamp);

}