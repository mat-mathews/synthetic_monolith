using Admin.Client;
using Admin.Contracts;
using Auth.Contracts402;
using Auth.Models236;
using Auth.Processors319;
using BatchJobs.Service;
using Billing.Handlers;
using Billing.Models;
using DataAccess.Handlers482;
using Documents.Service;
using Documents.Validators;
using Export.Processors426;
using Imaging.Events416;
using Integration.Contracts;
using Portal.Tests481;
using Reporting.Api;
using Scheduling.Validators;
using Security.Mappers313;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Utilities.Data
{
    public interface IUtilities_Data_Provider6
    {
        /// <summary>Processes the Utilities_Data_Provider6 operation.</summary>
        void ProcessUtilities_Data_Provider6();

        /// <summary>Validates the Utilities_Data_Provider6 state.</summary>
        bool ValidateUtilities_Data_Provider6();
    }

}