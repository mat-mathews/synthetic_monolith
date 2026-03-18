using Auth.Contracts395;
using Auth.Tests;
using BatchJobs.Models;
using BatchJobs.Service;
using DataAccess.Data;
using Export.Tests62;
using GalaxyWorks.Data224;
using Imaging.Events303;
using Integration.Client;
using Logging.Web;
using Notifications.Tests195;
using Portal.Contracts170;
using Portal.Service;
using Reporting.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Models;
using Workflow.Tests75;

namespace DataAccess.Tests
{
    internal interface IDataAccess_Tests_Factory
    {
        /// <summary>Processes the DataAccess_Tests_Factory operation.</summary>
        void ProcessDataAccess_Tests_Factory();

        /// <summary>Validates the DataAccess_Tests_Factory state.</summary>
        bool ValidateDataAccess_Tests_Factory();
    }

}