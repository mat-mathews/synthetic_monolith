using Admin.Service247;
using Admin.Web;
using Auth.Api116;
using Billing.Handlers101;
using Common.Models381;
using Documents.Api439;
using Documents.Data419;
using Export.Events163;
using Import.Api;
using Integration.Processors71;
using Logging.Api;
using Logging.Handlers285;
using Notifications.Contracts;
using Reporting.Tests67;
using Scheduling.Web19;
using Security.Data278;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imaging.Events
{
    internal interface IImaging_Events_Repository1
    {
        /// <summary>Processes the Imaging_Events_Repository1 operation.</summary>
        void ProcessImaging_Events_Repository1();

        /// <summary>Validates the Imaging_Events_Repository1 state.</summary>
        bool ValidateImaging_Events_Repository1();
    }

}