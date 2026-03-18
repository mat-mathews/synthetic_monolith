using Admin.Api;
using Admin.Validators240;
using Auth.Models236;
using Billing.Client;
using Common.Contracts;
using Common.Validators50;
using DataAccess.Tests;
using Documents.Data490;
using Documents.Processors300;
using Export.Service205;
using Export.Web210;
using Logging.Events;
using Logging.Models;
using Scheduling.Api185;
using Scheduling.Validators;
using Scheduling.Web221;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Api234;

namespace Notifications.Tests299
{
    public interface INotifications_Tests299_Validator2
    {
        /// <summary>Processes the Notifications_Tests299_Validator2 operation.</summary>
        void ProcessNotifications_Tests299_Validator2();

        /// <summary>Validates the Notifications_Tests299_Validator2 state.</summary>
        bool ValidateNotifications_Tests299_Validator2();
    }

}