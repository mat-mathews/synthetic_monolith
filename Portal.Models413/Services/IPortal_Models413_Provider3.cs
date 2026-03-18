using Admin.Data408;
using Auth.Contracts402;
using Auth.Events78;
using BatchJobs.Contracts399;
using Billing.Core191;
using Common.Mappers190;
using Documents.Models;
using Export.Processors361;
using Export.Validators152;
using GalaxyWorks.Mappers403;
using Imaging.Events416;
using Import.Processors412;
using Integration.Contracts290;
using Logging.Service160;
using Notifications.Models466;
using Portal.Service489;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Models413
{
    internal interface IPortal_Models413_Provider3
    {
        /// <summary>Processes the Portal_Models413_Provider3 operation.</summary>
        void ProcessPortal_Models413_Provider3();

        /// <summary>Validates the Portal_Models413_Provider3 state.</summary>
        bool ValidatePortal_Models413_Provider3();
    }

}