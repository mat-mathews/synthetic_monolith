using Admin.Client177;
using Auth.Client249;
using Auth.Data;
using Auth.Mappers;
using Auth.Validators;
using Billing.Api497;
using Billing.Processors;
using Billing.Validators;
using DataAccess.Api341;
using Documents.Client58;
using Import.Api179;
using Import.Handlers407;
using Integration.Events301;
using Notifications.Web90;
using Portal.Shared;
using Scheduling.Api3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reporting.Client146
{
    internal interface IReporting_Client146_Service
    {
        /// <summary>Processes the Reporting_Client146_Service operation.</summary>
        void ProcessReporting_Client146_Service();

        /// <summary>Validates the Reporting_Client146_Service state.</summary>
        bool ValidateReporting_Client146_Service();
    }

}