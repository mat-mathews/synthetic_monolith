using Admin.Contracts120;
using Admin.Data117;
using Billing.Api;
using Billing.Tests;
using Common.Api57;
using Common.Events367;
using Common.Models381;
using Common.Shared;
using Export.Mappers237;
using Import.Service15;
using Import.Service429;
using Integration.Models;
using Logging.Core;
using Security.Core;
using Security.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Models;

namespace Common.Client269
{
    internal interface ICommon_Client269_Service
    {
        /// <summary>Processes the Common_Client269_Service operation.</summary>
        void ProcessCommon_Client269_Service();

        /// <summary>Validates the Common_Client269_Service state.</summary>
        bool ValidateCommon_Client269_Service();
    }

}