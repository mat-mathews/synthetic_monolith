using Admin.Core121;
using Admin.Data408;
using Admin.Data465;
using Admin.Shared310;
using Admin.Web46;
using Auth.Contracts;
using Auth.Events5;
using Billing.Api9;
using Billing.Client182;
using Common.Core;
using DataAccess.Mappers;
using Documents.Api251;
using Portal.Api51;
using Reporting.Client;
using Reporting.Client146;
using Reporting.Data;
using Scheduling.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Web40;

namespace Portal.Events
{
    public interface IPortal_Events_Service
    {
        /// <summary>Processes the Portal_Events_Service operation.</summary>
        void ProcessPortal_Events_Service();

        /// <summary>Validates the Portal_Events_Service state.</summary>
        bool ValidatePortal_Events_Service();
    }

}