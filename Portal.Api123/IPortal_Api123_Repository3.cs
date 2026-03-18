using Admin.Data465;
using Admin.Handlers450;
using Auth.Models23;
using BatchJobs.Web;
using Documents.Data;
using Documents.Data490;
using Export.Api12;
using Export.Shared145;
using Export.Shared332;
using Export.Web210;
using Notifications.Validators252;
using Portal.Api51;
using Reporting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Api234;
using Utilities.Contracts24;
using Workflow.Mappers370;

namespace Portal.Api123
{
    public interface IPortal_Api123_Repository3
    {
        /// <summary>Processes the Portal_Api123_Repository3 operation.</summary>
        void ProcessPortal_Api123_Repository3();

        /// <summary>Validates the Portal_Api123_Repository3 state.</summary>
        bool ValidatePortal_Api123_Repository3();
    }

}