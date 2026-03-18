using Admin.Contracts;
using Auth.Core140;
using Auth.Data;
using Billing.Mappers;
using Common.Client269;
using Common.Data126;
using Common.Handlers;
using DataAccess.Data36;
using Export.Client414;
using Export.Contracts;
using GalaxyWorks.Contracts94;
using Integration.Web;
using Logging.Web;
using Portal.Handlers;
using Reporting.Shared394;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Data415;

namespace Common.Web
{
    /// <summary>Defines the possible states for Common_Web_Level1.</summary>
    internal enum Common_Web_Level1
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