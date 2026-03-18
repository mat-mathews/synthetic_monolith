using Admin.Shared310;
using Auth.Api;
using Documents.Tests458;
using Documents.Validators;
using GalaxyWorks.Data153;
using Imaging.Web;
using Import.Contracts131;
using Integration.Processors248;
using Integration.Validators;
using Logging.Tests292;
using Portal.Models413;
using Reporting.Api393;
using Security.Core243;
using Security.Models420;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Api66;
using Utilities.Data415;
using Utilities.Mappers97;

namespace Documents.Core
{
    /// <summary>Defines the possible states for Documents_Core_Category11.</summary>
    internal enum Documents_Core_Category11
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