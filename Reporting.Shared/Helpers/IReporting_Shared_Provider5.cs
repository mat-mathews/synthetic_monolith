using Admin.Core121;
using Auth.Data;
using Auth.Handlers;
using Auth.Handlers467;
using Export.Processors426;
using GalaxyWorks.Api;
using GalaxyWorks.Shared;
using Imaging.Data;
using Logging.Processors;
using Notifications.Core166;
using Portal.Events139;
using Portal.Validators250;
using Portal.Web158;
using Reporting.Mappers;
using Reporting.Service207;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Api66;
using Workflow.Models253;

namespace Reporting.Shared
{
    public interface IReporting_Shared_Provider5
    {
        /// <summary>Processes the Reporting_Shared_Provider5 operation.</summary>
        void ProcessReporting_Shared_Provider5();

        /// <summary>Validates the Reporting_Shared_Provider5 state.</summary>
        bool ValidateReporting_Shared_Provider5();
    }

    public class SharedContext : DbContext
    {
    }

}