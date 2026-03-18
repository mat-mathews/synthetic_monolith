using Admin.Validators431;
using Auth.Client;
using Auth.Contracts395;
using Billing.Client491;
using Billing.Shared312;
using Common.Api;
using Common.Core169;
using Export.Validators152;
using Imaging.Events;
using Import.Contracts296;
using Import.Data;
using Logging.Processors;
using Logging.Service;
using Reporting.Events317;
using Reporting.Web345;
using Security.Models;
using Security.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Mappers
{
    public interface IPortal_Mappers_Repository4
    {
        /// <summary>Processes the Portal_Mappers_Repository4 operation.</summary>
        void ProcessPortal_Mappers_Repository4();

        /// <summary>Validates the Portal_Mappers_Repository4 state.</summary>
        bool ValidatePortal_Mappers_Repository4();
    }

}