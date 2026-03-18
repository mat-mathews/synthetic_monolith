using Admin.Core;
using Auth.Data135;
using Auth.Events;
using Auth.Shared325;
using BatchJobs.Data;
using BatchJobs.Events435;
using BatchJobs.Handlers;
using DataAccess.Client82;
using GalaxyWorks.Client366;
using Imaging.Service;
using Logging.Data29;
using Logging.Handlers285;
using Portal.Api;
using Portal.Processors;
using Reporting.Contracts;
using Security.Contracts238;
using Security.Tests360;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Security.Contracts
{
    public interface ISecurity_Contracts_Repository
    {
        /// <summary>Processes the Security_Contracts_Repository operation.</summary>
        void ProcessSecurity_Contracts_Repository();

        /// <summary>Validates the Security_Contracts_Repository state.</summary>
        bool ValidateSecurity_Contracts_Repository();
    }

}