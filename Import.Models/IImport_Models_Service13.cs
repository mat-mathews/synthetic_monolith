using Admin.Data117;
using Admin.Handlers;
using Admin.Validators;
using Auth.Core2;
using Auth.Events5;
using BatchJobs.Processors410;
using Common.Api57;
using DataAccess.Contracts203;
using Export.Processors449;
using Imaging.Client;
using Import.Events493;
using Logging.Validators;
using Notifications.Data;
using Portal.Processors389;
using Portal.Validators227;
using Scheduling.Models260;
using Scheduling.Web60;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Import.Models
{
    public interface IImport_Models_Service13
    {
        /// <summary>Processes the Import_Models_Service13 operation.</summary>
        void ProcessImport_Models_Service13();

        /// <summary>Validates the Import_Models_Service13 state.</summary>
        bool ValidateImport_Models_Service13();
    }

}