using Admin.Validators37;
using Billing.Client22;
using DataAccess.Client;
using Documents.Data;
using Documents.Tests106;
using Export.Service30;
using Export.Web479;
using Imaging.Client331;
using Import.Mappers;
using Logging.Mappers;
using Notifications.Web;
using Portal.Data266;
using Portal.Validators;
using Scheduling.Tests;
using Security.Tests360;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Handlers462;

namespace BatchJobs.Mappers31
{
    public interface IBatchJobs_Mappers31_Provider6
    {
        /// <summary>Processes the BatchJobs_Mappers31_Provider6 operation.</summary>
        void ProcessBatchJobs_Mappers31_Provider6();

        /// <summary>Validates the BatchJobs_Mappers31_Provider6 state.</summary>
        bool ValidateBatchJobs_Mappers31_Provider6();
    }

}