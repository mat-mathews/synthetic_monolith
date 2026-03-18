using Admin.Client177;
using Admin.Handlers;
using Auth.Contracts402;
using Auth.Events78;
using Auth.Mappers28;
using Common.Client53;
using Common.Shared;
using Common.Validators;
using DataAccess.Client82;
using Imaging.Web;
using Import.Contracts;
using Import.Core;
using Logging.Client405;
using Portal.Validators125;
using Security.Core274;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Models253;
using Workflow.Processors;

namespace Notifications.Client
{
    internal interface INotifications_Client_Provider1
    {
        /// <summary>Processes the Notifications_Client_Provider1 operation.</summary>
        void ProcessNotifications_Client_Provider1();

        /// <summary>Validates the Notifications_Client_Provider1 state.</summary>
        bool ValidateNotifications_Client_Provider1();
    }

}