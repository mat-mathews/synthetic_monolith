using Admin.Data408;
using Admin.Models199;
using Auth.Mappers206;
using DataAccess.Api454;
using Documents.Service215;
using Documents.Shared452;
using GalaxyWorks.Contracts485;
using Import.Contracts183;
using Integration.Client;
using Integration.Handlers;
using Logging.Data;
using Logging.Service;
using Notifications.Tests195;
using Scheduling.Events128;
using Security.Client137;
using Security.Web376;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Data340;
using Workflow.Processors;

namespace Documents.Service471
{
    internal interface IDocuments_Service471_Repository5
    {
        /// <summary>Processes the Documents_Service471_Repository5 operation.</summary>
        void ProcessDocuments_Service471_Repository5();

        /// <summary>Validates the Documents_Service471_Repository5 state.</summary>
        bool ValidateDocuments_Service471_Repository5();
    }

}