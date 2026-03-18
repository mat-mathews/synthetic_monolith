using Admin.Contracts120;
using Admin.Handlers450;
using Common.Web;
using Export.Data150;
using Export.Handlers;
using GalaxyWorks.Mappers;
using Integration.Service401;
using Logging.Models379;
using Logging.Models436;
using Portal.Contracts;
using Security.Client;
using Security.Models18;
using Security.Shared155;
using Security.Shared365;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Handlers;
using Utilities.Models;

namespace Utilities.Data415
{
    public interface IUtilities_Data415_Repository2
    {
        /// <summary>Processes the Utilities_Data415_Repository2 operation.</summary>
        void ProcessUtilities_Data415_Repository2();

        /// <summary>Validates the Utilities_Data415_Repository2 state.</summary>
        bool ValidateUtilities_Data415_Repository2();
    }

}