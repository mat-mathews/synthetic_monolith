using Admin.Data408;
using Admin.Handlers447;
using Auth.Processors319;
using BatchJobs.Contracts;
using BatchJobs.Data;
using Billing.Service302;
using Common.Service;
using Export.Core168;
using Export.Models461;
using Imaging.Shared338;
using Logging.Mappers;
using Notifications.Web90;
using Portal.Core;
using Reporting.Mappers239;
using Reporting.Shared;
using Scheduling.Processors337;
using Security.Contracts72;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Tests350
{
    public interface ICommon_Tests350_Validator2
    {
        /// <summary>Processes the Common_Tests350_Validator2 operation.</summary>
        void ProcessCommon_Tests350_Validator2();

        /// <summary>Validates the Common_Tests350_Validator2 state.</summary>
        bool ValidateCommon_Tests350_Validator2();
    }

}