using Admin.Shared310;
using Auth.Api;
using Documents.Tests458;
using Documents.Validators;
using GalaxyWorks.Data153;
using Imaging.Web;
using Import.Contracts131;
using Integration.Processors248;
using Integration.Validators;
using Logging.Tests292;
using Portal.Models413;
using Reporting.Api393;
using Security.Core243;
using Security.Models420;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Api66;
using Utilities.Data415;
using Utilities.Mappers97;

namespace Documents.Core
{
    public interface IDocuments_Core_Handler2
    {
        /// <summary>Processes the Documents_Core_Handler2 operation.</summary>
        void ProcessDocuments_Core_Handler2();

        /// <summary>Validates the Documents_Core_Handler2 state.</summary>
        bool ValidateDocuments_Core_Handler2();
    }

    public class CoreContext : DbContext
    {
    }

}