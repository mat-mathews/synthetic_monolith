using Admin.Contracts120;
using Admin.Events235;
using Auth.Client271;
using Auth.Mappers;
using Auth.Mappers206;
using BatchJobs.Client;
using Billing.Api;
using Billing.Mappers198;
using Billing.Validators;
using DataAccess.Shared;
using Documents.Data;
using Documents.Processors;
using Export.Core386;
using Imaging.Shared338;
using Import.Api272;
using Integration.Handlers17;
using Notifications.Data348;
using Scheduling.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Service
{
    internal interface IDataAccess_Service_Provider3
    {
        /// <summary>Processes the DataAccess_Service_Provider3 operation.</summary>
        void ProcessDataAccess_Service_Provider3();

        /// <summary>Validates the DataAccess_Service_Provider3 state.</summary>
        bool ValidateDataAccess_Service_Provider3();
    }

}