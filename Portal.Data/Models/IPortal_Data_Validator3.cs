using Admin.Client;
using Admin.Service456;
using Auth.Mappers28;
using Billing.Handlers;
using Common.Models;
using Documents.Data492;
using Documents.Web;
using GalaxyWorks.Contracts485;
using Imaging.Client331;
using Imaging.Mappers;
using Imaging.Tests;
using Import.Data;
using Import.Processors;
using Logging.Handlers285;
using Portal.Validators;
using Security.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Mappers;

namespace Portal.Data
{
    internal interface IPortal_Data_Validator3
    {
        /// <summary>Processes the Portal_Data_Validator3 operation.</summary>
        void ProcessPortal_Data_Validator3();

        /// <summary>Validates the Portal_Data_Validator3 state.</summary>
        bool ValidatePortal_Data_Validator3();
    }

}