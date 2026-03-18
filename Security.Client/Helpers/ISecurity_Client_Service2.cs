using Admin.Validators;
using Auth.Events5;
using Auth.Mappers208;
using Auth.Mappers28;
using Auth.Models236;
using BatchJobs.Api212;
using DataAccess.Handlers;
using Documents.Events;
using Documents.Shared452;
using Import.Validators;
using Logging.Models436;
using Portal.Api;
using Portal.Api123;
using Reporting.Events483;
using Security.Models420;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Mappers232;

namespace Security.Client
{
    public interface ISecurity_Client_Service2
    {
        /// <summary>Processes the Security_Client_Service2 operation.</summary>
        void ProcessSecurity_Client_Service2();

        /// <summary>Validates the Security_Client_Service2 state.</summary>
        bool ValidateSecurity_Client_Service2();
    }

}