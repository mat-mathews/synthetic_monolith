using Admin.Events;
using Admin.Mappers324;
using Auth.Client;
using Auth.Mappers28;
using BatchJobs.Client109;
using Billing.Shared312;
using DataAccess.Contracts404;
using DataAccess.Shared;
using Export.Web130;
using Imaging.Events416;
using Imaging.Mappers;
using Import.Service15;
using Import.Service291;
using Integration.Handlers244;
using Integration.Web;
using Portal.Mappers;
using Portal.Validators125;
using Reporting.Api393;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imaging.Client331
{
    internal interface IImaging_Client331_Repository9
    {
        /// <summary>Processes the Imaging_Client331_Repository9 operation.</summary>
        void ProcessImaging_Client331_Repository9();

        /// <summary>Validates the Imaging_Client331_Repository9 state.</summary>
        bool ValidateImaging_Client331_Repository9();
    }

}