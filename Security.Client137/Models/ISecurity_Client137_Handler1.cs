using Admin.Data117;
using Admin.Events;
using Admin.Processors35;
using Auth.Api143;
using Auth.Validators;
using Export.Core168;
using Export.Shared332;
using Import.Client65;
using Portal.Validators;
using Reporting.Client146;
using Scheduling.Tests214;
using Scheduling.Tests444;
using Scheduling.Tests85;
using Scheduling.Web221;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Api;
using Workflow.Tests27;

namespace Security.Client137
{
    public interface ISecurity_Client137_Handler1
    {
        /// <summary>Processes the Security_Client137_Handler1 operation.</summary>
        void ProcessSecurity_Client137_Handler1();

        /// <summary>Validates the Security_Client137_Handler1 state.</summary>
        bool ValidateSecurity_Client137_Handler1();
    }

    public class Client137Context : DbContext
    {
    }

}