using Admin.Core121;
using Admin.Tests;
using Auth.Client271;
using Auth.Processors411;
using BatchJobs.Models;
using DataAccess.Client113;
using Documents.Shared487;
using Export.Processors104;
using GalaxyWorks.Client366;
using GalaxyWorks.Data375;
using Import.Events;
using Integration.Shared;
using Notifications.Tests299;
using Scheduling.Contracts425;
using Scheduling.Handlers63;
using Scheduling.Mappers;
using Security.Shared155;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imaging.Events416
{
    internal interface IImaging_Events416_Handler7
    {
        /// <summary>Processes the Imaging_Events416_Handler7 operation.</summary>
        void ProcessImaging_Events416_Handler7();

        /// <summary>Validates the Imaging_Events416_Handler7 state.</summary>
        bool ValidateImaging_Events416_Handler7();
    }

}