using Admin.Models;
using Auth.Events78;
using Auth.Handlers467;
using BatchJobs.Tests;
using Documents.Api251;
using Documents.Validators102;
using Export.Client414;
using GalaxyWorks.Api;
using GalaxyWorks.Core309;
using GalaxyWorks.Service293;
using Integration.Processors71;
using Notifications.Data;
using Reporting.Web;
using Security.Web230;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Events;
using Workflow.Service;
using Workflow.Service463;
using Workflow.Shared298;

namespace Imaging.Mappers275
{
    public interface IImaging_Mappers275_Validator3
    {
        /// <summary>Processes the Imaging_Mappers275_Validator3 operation.</summary>
        void ProcessImaging_Mappers275_Validator3();

        /// <summary>Validates the Imaging_Mappers275_Validator3 state.</summary>
        bool ValidateImaging_Mappers275_Validator3();
    }

    public class Mappers275Context : DbContext
    {
    }

}