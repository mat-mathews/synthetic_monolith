using Admin.Data408;
using Admin.Shared310;
using Admin.Web4;
using Auth.Contracts395;
using Auth.Shared325;
using Billing.Mappers;
using Common.Service;
using DataAccess.Api307;
using DataAccess.Tests286;
using Export.Validators152;
using Imaging.Client261;
using Import.Service291;
using Integration.Data;
using Portal.Service231;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Api;
using Workflow.Client351;

namespace DataAccess.Api
{
    internal interface IDataAccess_Api_Validator6
    {
        /// <summary>Processes the DataAccess_Api_Validator6 operation.</summary>
        void ProcessDataAccess_Api_Validator6();

        /// <summary>Validates the DataAccess_Api_Validator6 state.</summary>
        bool ValidateDataAccess_Api_Validator6();
    }

}