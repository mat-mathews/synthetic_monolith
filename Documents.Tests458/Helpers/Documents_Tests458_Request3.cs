using Admin.Api255;
using Auth.Mappers28;
using Auth.Models236;
using BatchJobs.Api501;
using BatchJobs.Core11;
using Billing.Mappers;
using Billing.Shared312;
using DataAccess.Api341;
using Documents.Core;
using Export.Service205;
using Logging.Service382;
using Portal.Service489;
using Scheduling.Client187;
using Scheduling.Shared39;
using Scheduling.Web221;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Mappers97;

namespace Documents.Tests458
{
    /// <summary>Immutable data transfer record for Documents_Tests458_Request3.</summary>
    internal record Documents_Tests458_Request3(string Value, int Count, DateTime Timestamp);

    public class Tests458Context : DbContext
    {
    }

}