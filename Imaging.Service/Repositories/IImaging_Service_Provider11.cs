using Auth.Data;
using Auth.Events5;
using Auth.Processors319;
using BatchJobs.Events435;
using Common.Api213;
using DataAccess.Events283;
using Documents.Api439;
using Documents.Validators;
using Documents.Validators102;
using Imaging.Events;
using Portal.Contracts181;
using Portal.Models413;
using Reporting.Contracts;
using Scheduling.Processors;
using Security.Models284;
using Security.Validators217;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imaging.Service
{
    internal interface IImaging_Service_Provider11
    {
        /// <summary>Processes the Imaging_Service_Provider11 operation.</summary>
        void ProcessImaging_Service_Provider11();

        /// <summary>Validates the Imaging_Service_Provider11 state.</summary>
        bool ValidateImaging_Service_Provider11();
    }

    public class ServiceContext : DbContext
    {
    }

}