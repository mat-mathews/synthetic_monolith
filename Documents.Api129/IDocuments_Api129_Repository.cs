using Admin.Core121;
using Admin.Events306;
using Auth.Core140;
using Auth.Processors400;
using Auth.Tests498;
using Billing.Api497;
using Billing.Tests;
using Common.Client53;
using DataAccess.Api98;
using Imaging.Core;
using Imaging.Tests328;
using Import.Api;
using Import.Core;
using Import.Models457;
using Logging.Handlers455;
using Logging.Validators359;
using Portal.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Documents.Api129
{
    public interface IDocuments_Api129_Repository
    {
        /// <summary>Processes the Documents_Api129_Repository operation.</summary>
        void ProcessDocuments_Api129_Repository();

        /// <summary>Validates the Documents_Api129_Repository state.</summary>
        bool ValidateDocuments_Api129_Repository();
    }

}