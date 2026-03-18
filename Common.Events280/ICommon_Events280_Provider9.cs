using Admin.Events306;
using Auth.Data;
using BatchJobs.Models304;
using DataAccess.Mappers;
using GalaxyWorks.Api;
using Integration.Mappers242;
using Portal.Core;
using Reporting.Mappers239;
using Scheduling.Api185;
using Scheduling.Models441;
using Scheduling.Shared;
using Security.Client349;
using Security.Mappers313;
using Security.Validators217;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Mappers;
using Workflow.Data340;

namespace Common.Events280
{
    public interface ICommon_Events280_Provider9
    {
        /// <summary>Processes the Common_Events280_Provider9 operation.</summary>
        void ProcessCommon_Events280_Provider9();

        /// <summary>Validates the Common_Events280_Provider9 state.</summary>
        bool ValidateCommon_Events280_Provider9();
    }

}