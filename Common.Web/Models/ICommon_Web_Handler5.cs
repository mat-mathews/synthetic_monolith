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
    public interface ICommon_Web_Handler5
    {
        /// <summary>Processes the Common_Web_Handler5 operation.</summary>
        void ProcessCommon_Web_Handler5();

        /// <summary>Validates the Common_Web_Handler5 state.</summary>
        bool ValidateCommon_Web_Handler5();
    }

}