using Admin.Handlers450;
using Admin.Tests;
using Admin.Validators240;
using Auth.Contracts395;
using Auth.Validators87;
using Billing.Events;
using Documents.Tests458;
using Export.Models262;
using Import.Validators;
using Logging.Api316;
using Logging.Service;
using Scheduling.Models260;
using Scheduling.Processors80;
using Security.Core;
using Security.Web230;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Mappers232;

namespace Portal.Validators125
{
    public interface IPortal_Validators125_Handler6
    {
        /// <summary>Processes the Portal_Validators125_Handler6 operation.</summary>
        void ProcessPortal_Validators125_Handler6();

        /// <summary>Validates the Portal_Validators125_Handler6 state.</summary>
        bool ValidatePortal_Validators125_Handler6();
    }

    public class Validators125Context : DbContext
    {
    }

}