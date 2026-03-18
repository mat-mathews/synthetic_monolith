using Admin.Client346;
using Admin.Handlers;
using Auth.Events5;
using BatchJobs.Data176;
using BatchJobs.Validators;
using Billing.Handlers122;
using Common.Client;
using DataAccess.Api98;
using Export.Processors426;
using Export.Service30;
using Integration.Shared83;
using Notifications.Handlers470;
using Portal.Validators69;
using Security.Client137;
using Security.Handlers;
using Security.Validators418;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Security.Contracts238
{
    public interface ISecurity_Contracts238_Provider6
    {
        /// <summary>Processes the Security_Contracts238_Provider6 operation.</summary>
        void ProcessSecurity_Contracts238_Provider6();

        /// <summary>Validates the Security_Contracts238_Provider6 state.</summary>
        bool ValidateSecurity_Contracts238_Provider6();
    }

}