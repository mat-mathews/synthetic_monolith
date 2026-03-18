using Admin.Data465;
using Admin.Handlers447;
using Admin.Validators37;
using Common.Contracts;
using DataAccess.Client82;
using DataAccess.Shared486;
using Export.Api;
using Export.Shared;
using GalaxyWorks.Contracts485;
using GalaxyWorks.Mappers318;
using Integration.Client;
using Integration.Mappers;
using Notifications.Core;
using Portal.Processors52;
using Reporting.Events;
using Reporting.Models;
using Scheduling.Api;
using Security.Contracts499;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GalaxyWorks.Data
{
    public interface IGalaxyWorks_Data_Provider3
    {
        /// <summary>Processes the GalaxyWorks_Data_Provider3 operation.</summary>
        void ProcessGalaxyWorks_Data_Provider3();

        /// <summary>Validates the GalaxyWorks_Data_Provider3 state.</summary>
        bool ValidateGalaxyWorks_Data_Provider3();
    }

}