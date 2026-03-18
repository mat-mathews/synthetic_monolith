using Admin.Api255;
using Admin.Events235;
using Admin.Processors;
using Admin.Validators;
using Auth.Client38;
using Auth.Processors;
using Billing.Core;
using Billing.Core191;
using Billing.Shared384;
using DataAccess.Contracts404;
using Export.Client414;
using Scheduling.Data;
using Scheduling.Mappers;
using Security.Core;
using Security.Shared155;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Contracts228;
using Utilities.Shared;
using Utilities.Shared114;

namespace DataAccess.Validators409
{
    public interface IDataAccess_Validators409_Provider5
    {
        /// <summary>Processes the DataAccess_Validators409_Provider5 operation.</summary>
        void ProcessDataAccess_Validators409_Provider5();

        /// <summary>Validates the DataAccess_Validators409_Provider5 state.</summary>
        bool ValidateDataAccess_Validators409_Provider5();
    }

}