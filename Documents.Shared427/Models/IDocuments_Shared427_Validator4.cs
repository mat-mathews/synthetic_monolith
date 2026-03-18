using Admin.Models199;
using Auth.Client249;
using Auth.Mappers;
using Auth.Processors400;
using BatchJobs.Validators;
using DataAccess.Data36;
using Documents.Core;
using Documents.Data;
using GalaxyWorks.Events256;
using Imaging.Events416;
using Imaging.Validators108;
using Logging.Data;
using Notifications.Shared380;
using Scheduling.Mappers;
using Scheduling.Service;
using Scheduling.Tests85;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Handlers;

namespace Documents.Shared427
{
    internal interface IDocuments_Shared427_Validator4
    {
        /// <summary>Processes the Documents_Shared427_Validator4 operation.</summary>
        void ProcessDocuments_Shared427_Validator4();

        /// <summary>Validates the Documents_Shared427_Validator4 state.</summary>
        bool ValidateDocuments_Shared427_Validator4();
    }

}