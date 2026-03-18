using Admin.Contracts;
using Admin.Service456;
using Admin.Shared363;
using Billing.Service302;
using Common.Web438;
using DataAccess.Validators88;
using Documents.Processors133;
using Documents.Tests171;
using GalaxyWorks.Contracts392;
using GalaxyWorks.Core309;
using Imaging.Tests;
using Notifications.Api;
using Portal.Api51;
using Reporting.Shared;
using Scheduling.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Contracts;
using Utilities.Data;

namespace Common.Data21
{
    internal interface ICommon_Data21_Provider
    {
        /// <summary>Processes the Common_Data21_Provider operation.</summary>
        void ProcessCommon_Data21_Provider();

        /// <summary>Validates the Common_Data21_Provider state.</summary>
        bool ValidateCommon_Data21_Provider();
    }

}