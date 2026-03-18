using Admin.Api;
using Admin.Client346;
using Admin.Validators37;
using BatchJobs.Contracts;
using BatchJobs.Mappers;
using BatchJobs.Validators311;
using DataAccess.Validators;
using Documents.Data484;
using Documents.Tests171;
using Documents.Web164;
using Imaging.Events416;
using Integration.Processors;
using Portal.Data;
using Reporting.Processors;
using Security.Validators418;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Mappers197;
using Workflow.Contracts434;

namespace Security.Mappers
{
    public interface ISecurity_Mappers_Handler9
    {
        /// <summary>Processes the Security_Mappers_Handler9 operation.</summary>
        void ProcessSecurity_Mappers_Handler9();

        /// <summary>Validates the Security_Mappers_Handler9 state.</summary>
        bool ValidateSecurity_Mappers_Handler9();
    }

}