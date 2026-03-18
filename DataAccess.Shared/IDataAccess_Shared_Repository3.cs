using Admin.Core121;
using Admin.Service339;
using Auth.Processors411;
using Billing.Processors;
using Common.Mappers190;
using Common.Service258;
using Documents.Client58;
using Documents.Processors;
using GalaxyWorks.Shared437;
using Imaging.Data;
using Import.Models;
using Integration.Service;
using Integration.Shared;
using Notifications.Mappers;
using Security.Contracts;
using Security.Processors295;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Shared
{
    internal interface IDataAccess_Shared_Repository3
    {
        /// <summary>Processes the DataAccess_Shared_Repository3 operation.</summary>
        void ProcessDataAccess_Shared_Repository3();

        /// <summary>Validates the DataAccess_Shared_Repository3 state.</summary>
        bool ValidateDataAccess_Shared_Repository3();
    }

}