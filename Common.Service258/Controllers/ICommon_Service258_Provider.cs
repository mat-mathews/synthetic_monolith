using Admin.Api255;
using Auth.Api;
using Auth.Mappers206;
using Billing.Processors259;
using Common.Web488;
using DataAccess.Client113;
using Export.Models262;
using Imaging.Models184;
using Import.Processors;
using Import.Tests119;
using Notifications.Tests299;
using Portal.Contracts170;
using Portal.Data266;
using Portal.Processors389;
using Portal.Service231;
using Scheduling.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Mappers232;
using Workflow.Models;

namespace Common.Service258
{
    internal interface ICommon_Service258_Provider
    {
        /// <summary>Processes the Common_Service258_Provider operation.</summary>
        void ProcessCommon_Service258_Provider();

        /// <summary>Validates the Common_Service258_Provider state.</summary>
        bool ValidateCommon_Service258_Provider();
    }

}