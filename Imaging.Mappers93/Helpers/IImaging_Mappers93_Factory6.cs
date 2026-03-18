using Admin.Handlers447;
using Admin.Models;
using Auth.Core140;
using Auth.Events;
using BatchJobs.Models329;
using Billing.Client;
using Billing.Client73;
using DataAccess.Api;
using Documents.Tests106;
using Documents.Web;
using Imaging.Shared322;
using Import.Service291;
using Integration.Processors321;
using Portal.Data216;
using Portal.Mappers;
using Scheduling.Processors25;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Handlers421;
using Workflow.Web377;

namespace Imaging.Mappers93
{
    public interface IImaging_Mappers93_Factory6
    {
        /// <summary>Processes the Imaging_Mappers93_Factory6 operation.</summary>
        void ProcessImaging_Mappers93_Factory6();

        /// <summary>Validates the Imaging_Mappers93_Factory6 state.</summary>
        bool ValidateImaging_Mappers93_Factory6();
    }

}