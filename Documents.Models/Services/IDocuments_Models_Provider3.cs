using Admin.Client177;
using Auth.Processors;
using BatchJobs.Api;
using Billing.Client491;
using Common.Contracts279;
using DataAccess.Mappers;
using DataAccess.Tests286;
using Export.Processors426;
using Import.Client64;
using Logging.Service160;
using Notifications.Service165;
using Portal.Tests173;
using Scheduling.Core480;
using Security.Processors246;
using Security.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Processors;
using Workflow.Tests;

namespace Documents.Models
{
    public interface IDocuments_Models_Provider3
    {
        /// <summary>Processes the Documents_Models_Provider3 operation.</summary>
        void ProcessDocuments_Models_Provider3();

        /// <summary>Validates the Documents_Models_Provider3 state.</summary>
        bool ValidateDocuments_Models_Provider3();
    }

    public class ModelsContext : DbContext
    {
    }

}