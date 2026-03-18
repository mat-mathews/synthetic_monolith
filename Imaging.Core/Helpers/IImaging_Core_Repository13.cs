using Admin.Processors35;
using Auth.Client249;
using Auth.Core2;
using Auth.Models;
using Auth.Shared325;
using Billing.Processors103;
using DataAccess.Contracts;
using DataAccess.Models;
using GalaxyWorks.Mappers;
using GalaxyWorks.Processors16;
using Imaging.Processors;
using Import.Contracts180;
using Integration.Data175;
using Logging.Shared315;
using Notifications.Shared380;
using Security.Processors;
using Security.Shared365;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Handlers421;

namespace Imaging.Core
{
    internal interface IImaging_Core_Repository13
    {
        /// <summary>Processes the Imaging_Core_Repository13 operation.</summary>
        void ProcessImaging_Core_Repository13();

        /// <summary>Validates the Imaging_Core_Repository13 state.</summary>
        bool ValidateImaging_Core_Repository13();
    }

}