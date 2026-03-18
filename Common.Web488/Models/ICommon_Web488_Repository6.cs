using Admin.Api;
using Admin.Client;
using Auth.Api;
using Auth.Data135;
using Auth.Events5;
using Auth.Mappers178;
using BatchJobs.Contracts;
using BatchJobs.Web;
using Common.Mappers343;
using GalaxyWorks.Shared;
using Imaging.Events424;
using Integration.Tests45;
using Portal.Models;
using Portal.Tests481;
using Reporting.Tests226;
using Scheduling.Processors;
using Security.Shared448;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Data340;

namespace Common.Web488
{
    public interface ICommon_Web488_Repository6
    {
        /// <summary>Processes the Common_Web488_Repository6 operation.</summary>
        void ProcessCommon_Web488_Repository6();

        /// <summary>Validates the Common_Web488_Repository6 state.</summary>
        bool ValidateCommon_Web488_Repository6();
    }

}