using Admin.Shared14;
using Auth.Api116;
using Auth.Data;
using Auth.Mappers28;
using Billing.Mappers;
using Common.Shared297;
using DataAccess.Api454;
using DataAccess.Service464;
using Documents.Contracts;
using Export.Core386;
using GalaxyWorks.Handlers;
using Imaging.Contracts89;
using Imaging.Core;
using Integration.Shared;
using Notifications.Shared396;
using Portal.Mappers;
using Security.Client137;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Events;

namespace Documents.Client58
{
    public interface IDocuments_Client58_Provider4
    {
        /// <summary>Processes the Documents_Client58_Provider4 operation.</summary>
        void ProcessDocuments_Client58_Provider4();

        /// <summary>Validates the Documents_Client58_Provider4 state.</summary>
        bool ValidateDocuments_Client58_Provider4();
    }

}