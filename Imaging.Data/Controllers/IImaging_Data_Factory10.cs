using Admin.Tests10;
using Auth.Core;
using BatchJobs.Api;
using BatchJobs.Validators311;
using Common.Service258;
using Documents.Client;
using Documents.Data484;
using GalaxyWorks.Data375;
using GalaxyWorks.Models;
using GalaxyWorks.Validators;
using Imaging.Mappers275;
using Imaging.Tests;
using Logging.Mappers;
using Portal.Service;
using Reporting.Api;
using Scheduling.Shared39;
using Security.Api320;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imaging.Data
{
    public interface IImaging_Data_Factory10
    {
        /// <summary>Processes the Imaging_Data_Factory10 operation.</summary>
        void ProcessImaging_Data_Factory10();

        /// <summary>Validates the Imaging_Data_Factory10 state.</summary>
        bool ValidateImaging_Data_Factory10();
    }

}