using Admin.Handlers61;
using Admin.Service456;
using Auth.Mappers208;
using Auth.Processors;
using Billing.Service;
using DataAccess.Contracts404;
using DataAccess.Core;
using Documents.Service471;
using GalaxyWorks.Mappers318;
using Imaging.Processors;
using Integration.Contracts;
using Logging.Web;
using Reporting.Handlers;
using Reporting.Tests67;
using Scheduling.Core273;
using Scheduling.Web19;
using Security.Shared365;
using Security.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Utilities.Api66
{
    /// <summary>Defines the possible states for Utilities_Api66_State6.</summary>
    public enum Utilities_Api66_State6
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