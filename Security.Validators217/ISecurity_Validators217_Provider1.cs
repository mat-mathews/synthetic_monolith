using Admin.Models199;
using BatchJobs.Events;
using Billing.Service302;
using Common.Processors142;
using Export.Contracts;
using GalaxyWorks.Events77;
using GalaxyWorks.Handlers;
using Imaging.Mappers;
using Import.Service496;
using Portal.Validators250;
using Scheduling.Processors397;
using Security.Core243;
using Security.Shared365;
using Security.Web230;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Contracts;
using Utilities.Contracts32;

namespace Security.Validators217
{
    public interface ISecurity_Validators217_Provider1
    {
        /// <summary>Processes the Security_Validators217_Provider1 operation.</summary>
        void ProcessSecurity_Validators217_Provider1();

        /// <summary>Validates the Security_Validators217_Provider1 state.</summary>
        bool ValidateSecurity_Validators217_Provider1();
    }

}