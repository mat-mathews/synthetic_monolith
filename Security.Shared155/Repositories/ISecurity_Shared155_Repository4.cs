using Admin.Service339;
using Admin.Service456;
using Admin.Web;
using BatchJobs.Processors;
using Common.Events280;
using Export.Core168;
using Export.Validators152;
using GalaxyWorks.Contracts94;
using GalaxyWorks.Events256;
using Imaging.Shared115;
using Import.Client356;
using Integration.Service107;
using Logging.Shared315;
using Notifications.Tests;
using Portal.Mappers233;
using Portal.Web494;
using Reporting.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Security.Shared155
{
    public interface ISecurity_Shared155_Repository4
    {
        /// <summary>Processes the Security_Shared155_Repository4 operation.</summary>
        void ProcessSecurity_Shared155_Repository4();

        /// <summary>Validates the Security_Shared155_Repository4 state.</summary>
        bool ValidateSecurity_Shared155_Repository4();
    }

}