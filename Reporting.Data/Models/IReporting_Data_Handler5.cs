using Admin.Contracts;
using Admin.Mappers324;
using Auth.Api;
using Auth.Data;
using Auth.Handlers281;
using Billing.Validators174;
using Common.Validators50;
using DataAccess.Data474;
using Documents.Data419;
using Documents.Tests171;
using Export.Processors;
using Import.Data100;
using Integration.Processors;
using Notifications.Data348;
using Scheduling.Contracts;
using Scheduling.Processors25;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Models41;

namespace Reporting.Data
{
    internal interface IReporting_Data_Handler5
    {
        /// <summary>Processes the Reporting_Data_Handler5 operation.</summary>
        void ProcessReporting_Data_Handler5();

        /// <summary>Validates the Reporting_Data_Handler5 state.</summary>
        bool ValidateReporting_Data_Handler5();
    }

}