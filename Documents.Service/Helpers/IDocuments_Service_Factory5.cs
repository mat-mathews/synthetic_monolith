using Admin.Shared363;
using Admin.Web46;
using Auth.Client;
using Auth.Contracts;
using BatchJobs.Api;
using BatchJobs.Client109;
using Common.Service258;
using GalaxyWorks.Processors16;
using Imaging.Validators;
using Import.Client;
using Import.Service291;
using Integration.Service147;
using Integration.Validators369;
using Notifications.Client257;
using Notifications.Data;
using Portal.Contracts181;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Documents.Service
{
    public interface IDocuments_Service_Factory5
    {
        /// <summary>Processes the Documents_Service_Factory5 operation.</summary>
        void ProcessDocuments_Service_Factory5();

        /// <summary>Validates the Documents_Service_Factory5 state.</summary>
        bool ValidateDocuments_Service_Factory5();
    }

}