using Admin.Contracts120;
using Admin.Data408;
using Admin.Service;
using Admin.Shared14;
using Auth.Mappers;
using BatchJobs.Handlers443;
using Common.Contracts279;
using Common.Shared;
using Common.Tests350;
using DataAccess.Models;
using Documents.Core;
using Documents.Data419;
using Imaging.Api127;
using Import.Validators;
using Logging.Mappers157;
using Portal.Models413;
using Reporting.Processors;
using Scheduling.Processors25;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Service231
{
    internal interface IPortal_Service231_Handler7
    {
        /// <summary>Processes the Portal_Service231_Handler7 operation.</summary>
        void ProcessPortal_Service231_Handler7();

        /// <summary>Validates the Portal_Service231_Handler7 state.</summary>
        bool ValidatePortal_Service231_Handler7();
    }

}