using Admin.Client177;
using Admin.Shared363;
using Auth.Client38;
using Auth.Contracts402;
using Common.Core417;
using DataAccess.Contracts;
using Documents.Api156;
using Export.Processors449;
using Export.Tests;
using GalaxyWorks.Data375;
using Imaging.Api127;
using Imaging.Mappers93;
using Logging.Validators359;
using Portal.Events;
using Reporting.Validators;
using Scheduling.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Validators
{
    public interface IPortal_Validators_Repository3
    {
        /// <summary>Processes the Portal_Validators_Repository3 operation.</summary>
        void ProcessPortal_Validators_Repository3();

        /// <summary>Validates the Portal_Validators_Repository3 state.</summary>
        bool ValidatePortal_Validators_Repository3();
    }

}