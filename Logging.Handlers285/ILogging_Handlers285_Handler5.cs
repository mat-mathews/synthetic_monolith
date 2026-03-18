using Admin.Contracts;
using Admin.Mappers;
using Admin.Models;
using Auth.Api116;
using Auth.Web70;
using BatchJobs.Contracts;
using Billing.Processors388;
using DataAccess.Service464;
using Export.Models461;
using Imaging.Processors;
using Import.Mappers56;
using Integration.Service401;
using Integration.Shared;
using Notifications.Service;
using Reporting.Contracts371;
using Security.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logging.Handlers285
{
    public interface ILogging_Handlers285_Handler5
    {
        /// <summary>Processes the Logging_Handlers285_Handler5 operation.</summary>
        void ProcessLogging_Handlers285_Handler5();

        /// <summary>Validates the Logging_Handlers285_Handler5 state.</summary>
        bool ValidateLogging_Handlers285_Handler5();
    }

}