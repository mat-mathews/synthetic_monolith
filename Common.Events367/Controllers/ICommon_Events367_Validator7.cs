using Auth.Models236;
using Billing.Client22;
using Billing.Service432;
using Documents.Processors;
using Imaging.Shared338;
using Import.Service15;
using Integration.Processors71;
using Logging.Validators359;
using Notifications.Data348;
using Notifications.Tests299;
using Notifications.Validators252;
using Portal.Processors52;
using Portal.Validators227;
using Scheduling.Client187;
using Scheduling.Web196;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Service;

namespace Common.Events367
{
    internal interface ICommon_Events367_Validator7
    {
        /// <summary>Processes the Common_Events367_Validator7 operation.</summary>
        void ProcessCommon_Events367_Validator7();

        /// <summary>Validates the Common_Events367_Validator7 state.</summary>
        bool ValidateCommon_Events367_Validator7();
    }

}