using Admin.Client;
using Admin.Data;
using Admin.Validators240;
using Auth.Events5;
using Auth.Mappers;
using Billing.Processors;
using Export.Core386;
using Imaging.Contracts;
using Integration.Tests92;
using Logging.Handlers455;
using Portal.Api;
using Portal.Web494;
using Reporting.Events317;
using Reporting.Validators;
using Scheduling.Handlers43;
using Security.Validators428;
using Security.Web376;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Events;

namespace Security.Core274
{
    /// <summary>Defines the possible states for Security_Core274_Status7.</summary>
    public enum Security_Core274_Status7
    {
        None = 0,
        Active = 1,
        Inactive = 2,
        Pending = 3,
        Processing = 4,
        Completed = 5,
        Failed = 6,
    }

}