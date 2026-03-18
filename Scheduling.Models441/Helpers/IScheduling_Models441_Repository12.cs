using Admin.Core121;
using Admin.Data408;
using Admin.Handlers447;
using Auth.Service;
using BatchJobs.Data176;
using BatchJobs.Mappers362;
using Common.Data126;
using DataAccess.Validators254;
using Documents.Events;
using Import.Events493;
using Import.Validators;
using Integration.Processors71;
using Logging.Data29;
using Logging.Handlers285;
using Notifications.Tests;
using Portal.Client;
using Scheduling.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scheduling.Models441
{
    public interface IScheduling_Models441_Repository12
    {
        /// <summary>Processes the Scheduling_Models441_Repository12 operation.</summary>
        void ProcessScheduling_Models441_Repository12();

        /// <summary>Validates the Scheduling_Models441_Repository12 state.</summary>
        bool ValidateScheduling_Models441_Repository12();
    }

}