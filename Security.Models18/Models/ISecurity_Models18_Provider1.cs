using Admin.Models199;
using Admin.Tests;
using Admin.Validators;
using Auth.Core140;
using Auth.Web70;
using Billing.Core191;
using Common.Events367;
using DataAccess.Shared189;
using Imaging.Shared322;
using Notifications.Core166;
using Portal.Contracts170;
using Portal.Data216;
using Reporting.Shared;
using Scheduling.Core480;
using Scheduling.Models342;
using Security.Contracts72;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Processors91;

namespace Security.Models18
{
    internal interface ISecurity_Models18_Provider1
    {
        /// <summary>Processes the Security_Models18_Provider1 operation.</summary>
        void ProcessSecurity_Models18_Provider1();

        /// <summary>Validates the Security_Models18_Provider1 state.</summary>
        bool ValidateSecurity_Models18_Provider1();
    }

}