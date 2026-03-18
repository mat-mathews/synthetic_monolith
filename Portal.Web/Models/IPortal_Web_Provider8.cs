using Admin.Events235;
using Admin.Shared363;
using Auth.Events78;
using Auth.Models236;
using Billing.Processors388;
using DataAccess.Contracts203;
using Export.Core168;
using Export.Validators;
using Export.Validators152;
using Import.Handlers407;
using Import.Service291;
using Reporting.Client422;
using Reporting.Events317;
using Scheduling.Client;
using Scheduling.Web264;
using Security.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Web;

namespace Portal.Web
{
    internal interface IPortal_Web_Provider8
    {
        /// <summary>Processes the Portal_Web_Provider8 operation.</summary>
        void ProcessPortal_Web_Provider8();

        /// <summary>Validates the Portal_Web_Provider8 state.</summary>
        bool ValidatePortal_Web_Provider8();
    }

}