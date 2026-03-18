using Admin.Client;
using Admin.Shared310;
using Auth.Api143;
using Auth.Client271;
using Auth.Processors400;
using BatchJobs.Web;
using Documents.Data492;
using Export.Data;
using Imaging.Contracts473;
using Imaging.Web172;
using Import.Client356;
using Logging.Client;
using Logging.Models379;
using Reporting.Mappers239;
using Scheduling.Processors80;
using Security.Client;
using Security.Client353;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Api
{
    internal interface IPortal_Api_Repository6
    {
        /// <summary>Processes the Portal_Api_Repository6 operation.</summary>
        void ProcessPortal_Api_Repository6();

        /// <summary>Validates the Portal_Api_Repository6 state.</summary>
        bool ValidatePortal_Api_Repository6();
    }

}