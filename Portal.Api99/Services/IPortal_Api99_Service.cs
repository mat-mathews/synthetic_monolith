using Auth.Processors;
using BatchJobs.Client;
using DataAccess.Api98;
using DataAccess.Client82;
using Documents.Api132;
using Export.Core168;
using GalaxyWorks.Events;
using GalaxyWorks.Handlers385;
using Imaging.Processors;
using Integration.Api469;
using Reporting.Handlers;
using Security.Processors;
using Security.Shared155;
using Security.Web376;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Data415;
using Utilities.Events;

namespace Portal.Api99
{
    internal interface IPortal_Api99_Service
    {
        /// <summary>Processes the Portal_Api99_Service operation.</summary>
        void ProcessPortal_Api99_Service();

        /// <summary>Validates the Portal_Api99_Service state.</summary>
        bool ValidatePortal_Api99_Service();
    }

}