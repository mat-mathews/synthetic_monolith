using Admin.Core;
using Admin.Shared14;
using Auth.Client249;
using Auth.Events5;
using Auth.Mappers206;
using Common.Shared;
using Documents.Core357;
using Imaging.Mappers;
using Import.Client;
using Integration.Service477;
using Integration.Validators369;
using Logging.Contracts;
using Logging.Core159;
using Portal.Client;
using Security.Models18;
using Security.Service383;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Client351;
using Workflow.Validators;

namespace Portal.Service
{
    public interface IPortal_Service_Repository1
    {
        /// <summary>Processes the Portal_Service_Repository1 operation.</summary>
        void ProcessPortal_Service_Repository1();

        /// <summary>Validates the Portal_Service_Repository1 state.</summary>
        bool ValidatePortal_Service_Repository1();
    }

}