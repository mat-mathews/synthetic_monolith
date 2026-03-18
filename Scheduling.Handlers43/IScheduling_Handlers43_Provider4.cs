using Admin.Service;
using Auth.Contracts;
using Auth.Handlers;
using BatchJobs.Processors410;
using Billing.Models;
using Documents.Data;
using Export.Processors449;
using Export.Service;
using GalaxyWorks.Processors;
using Imaging.Api;
using Imaging.Mappers;
using Import.Api179;
using Import.Validators;
using Integration.Processors71;
using Portal.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Web;

namespace Scheduling.Handlers43
{
    internal interface IScheduling_Handlers43_Provider4
    {
        /// <summary>Processes the Scheduling_Handlers43_Provider4 operation.</summary>
        void ProcessScheduling_Handlers43_Provider4();

        /// <summary>Validates the Scheduling_Handlers43_Provider4 state.</summary>
        bool ValidateScheduling_Handlers43_Provider4();
    }

}