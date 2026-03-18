using Admin.Core;
using Auth.Handlers467;
using Auth.Processors319;
using BatchJobs.Web;
using Billing.Processors259;
using Common.Api213;
using Common.Web488;
using Documents.Contracts;
using Export.Client;
using Export.Service30;
using Imaging.Events;
using Import.Client7;
using Integration.Service107;
using Logging.Data29;
using Logging.Service382;
using Reporting.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration.Web
{
    /// <summary>Immutable data transfer record for Integration_Web_Event2.</summary>
    internal record Integration_Web_Event2(string Value, int Count, DateTime Timestamp);

    public class WebContext : DbContext
    {
    }

}