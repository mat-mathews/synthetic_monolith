using Admin.Web;
using Auth.Contracts395;
using Auth.Core;
using BatchJobs.Api212;
using Billing.Shared;
using Common.Service;
using DataAccess.Core;
using Export.Models461;
using GalaxyWorks.Processors;
using Imaging.Contracts;
using Imaging.Contracts89;
using Import.Contracts131;
using Integration.Mappers;
using Integration.Processors71;
using Notifications.Api144;
using Scheduling.Models;
using Security.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Mappers;

namespace Security.Data278
{
    public interface ISecurity_Data278_Factory13
    {
        /// <summary>Processes the Security_Data278_Factory13 operation.</summary>
        void ProcessSecurity_Data278_Factory13();

        /// <summary>Validates the Security_Data278_Factory13 state.</summary>
        bool ValidateSecurity_Data278_Factory13();
    }

}