using Auth.Contracts;
using Auth.Core2;
using Auth.Events5;
using Auth.Events78;
using BatchJobs.Events435;
using BatchJobs.Mappers362;
using Billing.Processors103;
using Common.Client53;
using DataAccess.Api341;
using DataAccess.Api454;
using Imaging.Shared115;
using Notifications.Api144;
using Scheduling.Models441;
using Security.Shared365;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Api66;
using Utilities.Models;

namespace Import.Service265
{
    internal interface IImport_Service265_Validator6
    {
        /// <summary>Processes the Import_Service265_Validator6 operation.</summary>
        void ProcessImport_Service265_Validator6();

        /// <summary>Validates the Import_Service265_Validator6 state.</summary>
        bool ValidateImport_Service265_Validator6();
    }

}