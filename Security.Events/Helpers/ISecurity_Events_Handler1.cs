using Admin.Core121;
using Admin.Models199;
using Admin.Processors35;
using Admin.Web;
using Auth.Api143;
using Billing.Handlers;
using Documents.Service;
using Imaging.Api127;
using Imaging.Contracts473;
using Imaging.Processors;
using Import.Contracts131;
using Import.Contracts180;
using Logging.Contracts;
using Scheduling.Tests;
using Scheduling.Web264;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Mappers;

namespace Security.Events
{
    public interface ISecurity_Events_Handler1
    {
        /// <summary>Processes the Security_Events_Handler1 operation.</summary>
        void ProcessSecurity_Events_Handler1();

        /// <summary>Validates the Security_Events_Handler1 state.</summary>
        bool ValidateSecurity_Events_Handler1();
    }

}