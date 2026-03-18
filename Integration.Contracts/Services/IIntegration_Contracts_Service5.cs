using Admin.Data117;
using Admin.Events235;
using Admin.Processors;
using Auth.Handlers467;
using Auth.Mappers;
using Auth.Processors400;
using BatchJobs.Processors;
using Billing.Mappers225;
using DataAccess.Service464;
using DataAccess.Shared189;
using Export.Events163;
using Export.Mappers;
using Export.Processors426;
using Import.Service265;
using Notifications.Api144;
using Portal.Api;
using Portal.Validators227;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Web;

namespace Integration.Contracts
{
    internal interface IIntegration_Contracts_Service5
    {
        /// <summary>Processes the Integration_Contracts_Service5 operation.</summary>
        void ProcessIntegration_Contracts_Service5();

        /// <summary>Validates the Integration_Contracts_Service5 state.</summary>
        bool ValidateIntegration_Contracts_Service5();
    }

}