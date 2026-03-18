using Admin.Events;
using Admin.Handlers61;
using Admin.Validators37;
using Auth.Data;
using Auth.Mappers206;
using Auth.Models236;
using Common.Events367;
using DataAccess.Service464;
using DataAccess.Validators409;
using Export.Events;
using Imaging.Tests;
using Import.Client7;
using Import.Contracts131;
using Notifications.Core166;
using Scheduling.Web221;
using Scheduling.Web264;
using Security.Api134;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Web;

namespace Documents.Shared487
{
    public interface IDocuments_Shared487_Repository8
    {
        /// <summary>Processes the Documents_Shared487_Repository8 operation.</summary>
        void ProcessDocuments_Shared487_Repository8();

        /// <summary>Validates the Documents_Shared487_Repository8 state.</summary>
        bool ValidateDocuments_Shared487_Repository8();
    }

}