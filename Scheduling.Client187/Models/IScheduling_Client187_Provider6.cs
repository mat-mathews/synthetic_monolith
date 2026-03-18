using Admin.Handlers447;
using Admin.Service;
using Billing.Api497;
using DataAccess.Contracts404;
using DataAccess.Models;
using Export.Web229;
using GalaxyWorks.Tests;
using Imaging.Contracts473;
using Integration.Processors;
using Logging.Data;
using Logging.Shared315;
using Notifications.Client;
using Portal.Web;
using Reporting.Tests226;
using Scheduling.Web264;
using Security.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Handlers421;

namespace Scheduling.Client187
{
    internal interface IScheduling_Client187_Provider6
    {
        /// <summary>Processes the Scheduling_Client187_Provider6 operation.</summary>
        void ProcessScheduling_Client187_Provider6();

        /// <summary>Validates the Scheduling_Client187_Provider6 state.</summary>
        bool ValidateScheduling_Client187_Provider6();
    }

}