using Admin.Processors35;
using BatchJobs.Handlers;
using Common.Events;
using Common.Models;
using Common.Validators;
using DataAccess.Contracts404;
using DataAccess.Shared;
using DataAccess.Tests286;
using Documents.Processors;
using Export.Service;
using Imaging.Client261;
using Imaging.Mappers93;
using Notifications.Events42;
using Notifications.Shared396;
using Portal.Tests173;
using Scheduling.Models342;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scheduling.Service
{
    public interface IScheduling_Service_Handler4
    {
        /// <summary>Processes the Scheduling_Service_Handler4 operation.</summary>
        void ProcessScheduling_Service_Handler4();

        /// <summary>Validates the Scheduling_Service_Handler4 state.</summary>
        bool ValidateScheduling_Service_Handler4();
    }

    public class ServiceContext : DbContext
    {
    }

}