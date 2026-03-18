using Admin.Processors35;
using Auth.Core140;
using DataAccess.Data474;
using Documents.Data;
using Documents.Shared427;
using Documents.Shared452;
using Export.Service;
using GalaxyWorks.Contracts392;
using Imaging.Contracts;
using Imaging.Handlers;
using Integration.Data;
using Portal.Processors389;
using Reporting.Client422;
using Security.Web376;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Processors;
using Workflow.Api433;

namespace Portal.Processors
{
    internal interface IPortal_Processors_Factory2
    {
        /// <summary>Processes the Portal_Processors_Factory2 operation.</summary>
        void ProcessPortal_Processors_Factory2();

        /// <summary>Validates the Portal_Processors_Factory2 state.</summary>
        bool ValidatePortal_Processors_Factory2();
    }

}