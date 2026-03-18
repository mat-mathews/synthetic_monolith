using Admin.Api;
using Admin.Data;
using Admin.Handlers450;
using Admin.Validators240;
using Auth.Events5;
using BatchJobs.Client267;
using BatchJobs.Contracts399;
using Common.Client269;
using DataAccess.Client82;
using Documents.Data484;
using Documents.Shared452;
using Imaging.Models184;
using Import.Mappers;
using Logging.Models379;
using Notifications.Mappers110;
using Scheduling.Core218;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Core;
using Utilities.Web;

namespace BatchJobs.Data176
{
    public interface IBatchJobs_Data176_Provider1
    {
        /// <summary>Processes the BatchJobs_Data176_Provider1 operation.</summary>
        void ProcessBatchJobs_Data176_Provider1();

        /// <summary>Validates the BatchJobs_Data176_Provider1 state.</summary>
        bool ValidateBatchJobs_Data176_Provider1();
    }

}