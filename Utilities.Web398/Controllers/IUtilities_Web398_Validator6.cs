using Admin.Api255;
using Admin.Core121;
using Auth.Api143;
using Auth.Data135;
using Auth.Events5;
using Auth.Models23;
using Auth.Tests498;
using Billing.Processors;
using Billing.Service302;
using DataAccess.Api;
using Imaging.Validators;
using Integration.Data175;
using Logging.Web;
using Reporting.Mappers;
using Scheduling.Shared39;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Contracts;

namespace Utilities.Web398
{
    internal interface IUtilities_Web398_Validator6
    {
        /// <summary>Processes the Utilities_Web398_Validator6 operation.</summary>
        void ProcessUtilities_Web398_Validator6();

        /// <summary>Validates the Utilities_Web398_Validator6 state.</summary>
        bool ValidateUtilities_Web398_Validator6();
    }

}