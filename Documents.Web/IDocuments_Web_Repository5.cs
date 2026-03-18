using Auth.Data;
using Auth.Mappers;
using Auth.Processors400;
using BatchJobs.Contracts;
using BatchJobs.Web;
using DataAccess.Client;
using DataAccess.Contracts404;
using Documents.Api251;
using Export.Shared332;
using GalaxyWorks.Shared437;
using Import.Processors412;
using Portal.Tests;
using Reporting.Processors;
using Scheduling.Handlers;
using Scheduling.Models;
using Security.Models;
using Security.Service;
using Security.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Documents.Web
{
    internal interface IDocuments_Web_Repository5
    {
        /// <summary>Processes the Documents_Web_Repository5 operation.</summary>
        void ProcessDocuments_Web_Repository5();

        /// <summary>Validates the Documents_Web_Repository5 state.</summary>
        bool ValidateDocuments_Web_Repository5();
    }

}