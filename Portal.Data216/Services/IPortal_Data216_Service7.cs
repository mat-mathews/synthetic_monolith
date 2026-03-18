using Admin.Api255;
using Admin.Core;
using Admin.Handlers447;
using Auth.Models236;
using Billing.Core191;
using Billing.Mappers198;
using DataAccess.Handlers;
using Export.Processors111;
using Imaging.Events416;
using Imaging.Shared;
using Integration.Handlers333;
using Logging.Handlers141;
using Notifications.Shared396;
using Portal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Validators;
using Workflow.Contracts;

namespace Portal.Data216
{
    internal interface IPortal_Data216_Service7
    {
        /// <summary>Processes the Portal_Data216_Service7 operation.</summary>
        void ProcessPortal_Data216_Service7();

        /// <summary>Validates the Portal_Data216_Service7 state.</summary>
        bool ValidatePortal_Data216_Service7();
    }

}