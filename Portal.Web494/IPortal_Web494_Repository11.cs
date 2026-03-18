using Admin.Client346;
using Admin.Data;
using Admin.Events;
using Admin.Handlers450;
using Admin.Validators431;
using Auth.Processors;
using Common.Processors142;
using DataAccess.Validators254;
using Documents.Handlers;
using Export.Events163;
using GalaxyWorks.Handlers;
using Integration.Contracts;
using Integration.Models;
using Portal.Mappers233;
using Reporting.Web345;
using Security.Models;
using Security.Tests223;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Api;

namespace Portal.Web494
{
    internal interface IPortal_Web494_Repository11
    {
        /// <summary>Processes the Portal_Web494_Repository11 operation.</summary>
        void ProcessPortal_Web494_Repository11();

        /// <summary>Validates the Portal_Web494_Repository11 state.</summary>
        bool ValidatePortal_Web494_Repository11();
    }

}