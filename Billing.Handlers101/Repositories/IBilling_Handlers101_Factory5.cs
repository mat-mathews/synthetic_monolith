using Auth.Client;
using Auth.Events5;
using Auth.Handlers467;
using Auth.Models236;
using Billing.Client182;
using DataAccess.Api341;
using DataAccess.Tests282;
using Imaging.Shared115;
using Import.Handlers407;
using Integration.Data;
using Integration.Tests45;
using Logging.Service;
using Notifications.Service475;
using Reporting.Contracts371;
using Reporting.Service;
using Scheduling.Models342;
using Scheduling.Service211;
using Security.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billing.Handlers101
{
    internal interface IBilling_Handlers101_Factory5
    {
        /// <summary>Processes the Billing_Handlers101_Factory5 operation.</summary>
        void ProcessBilling_Handlers101_Factory5();

        /// <summary>Validates the Billing_Handlers101_Factory5 state.</summary>
        bool ValidateBilling_Handlers101_Factory5();
    }

}