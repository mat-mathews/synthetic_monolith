using Admin.Validators37;
using Auth.Core;
using Auth.Events;
using Auth.Mappers206;
using Auth.Models236;
using BatchJobs.Tests;
using Billing.Events;
using Billing.Validators305;
using Documents.Data;
using Import.Contracts296;
using Logging.Contracts373;
using Portal.Api51;
using Scheduling.Contracts;
using Scheduling.Web221;
using Security.Contracts72;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Data415;

namespace Security.Web376
{
    /// <summary>Immutable data transfer record for Security_Web376_Response3.</summary>
    public record Security_Web376_Response3(string Value, int Count, DateTime Timestamp);

}