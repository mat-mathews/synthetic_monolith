using Admin.Client346;
using Admin.Handlers;
using BatchJobs.Client267;
using BatchJobs.Models304;
using BatchJobs.Service;
using Common.Data126;
using Export.Data150;
using Export.Web479;
using Import.Contracts296;
using Import.Tests;
using Notifications.Validators;
using Notifications.Web308;
using Portal.Tests323;
using Portal.Web;
using Security.Client137;
using Security.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Handlers;

namespace Import.Api272
{
    internal interface IImport_Api272_Provider3
    {
        /// <summary>Processes the Import_Api272_Provider3 operation.</summary>
        void ProcessImport_Api272_Provider3();

        /// <summary>Validates the Import_Api272_Provider3 state.</summary>
        bool ValidateImport_Api272_Provider3();
    }

}