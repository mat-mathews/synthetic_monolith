using Admin.Validators336;
using Auth.Processors;
using Billing.Handlers;
using Common.Service;
using DataAccess.Core;
using DataAccess.Data36;
using Documents.Api439;
using Documents.Service;
using Export.Events;
using GalaxyWorks.Api;
using Import.Contracts180;
using Logging.Core;
using Portal.Handlers;
using Portal.Models413;
using Security.Handlers;
using Security.Shared365;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Service378
{
    internal interface IPortal_Service378_Provider8
    {
        /// <summary>Processes the Portal_Service378_Provider8 operation.</summary>
        void ProcessPortal_Service378_Provider8();

        /// <summary>Validates the Portal_Service378_Provider8 state.</summary>
        bool ValidatePortal_Service378_Provider8();
    }

}