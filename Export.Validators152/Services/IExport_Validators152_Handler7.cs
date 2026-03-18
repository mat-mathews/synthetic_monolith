using Admin.Core121;
using Auth.Client38;
using Auth.Data;
using Auth.Events5;
using Auth.Handlers467;
using BatchJobs.Models;
using BatchJobs.Service;
using Documents.Shared427;
using Export.Processors104;
using Export.Shared145;
using GalaxyWorks.Core;
using Imaging.Web;
using Import.Contracts180;
using Notifications.Shared380;
using Notifications.Validators391;
using Portal.Events139;
using Portal.Web494;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Service;

namespace Export.Validators152
{
    public interface IExport_Validators152_Handler7
    {
        /// <summary>Processes the Export_Validators152_Handler7 operation.</summary>
        void ProcessExport_Validators152_Handler7();

        /// <summary>Validates the Export_Validators152_Handler7 state.</summary>
        bool ValidateExport_Validators152_Handler7();
    }

}