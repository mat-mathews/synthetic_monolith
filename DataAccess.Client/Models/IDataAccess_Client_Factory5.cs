using Admin.Models476;
using Auth.Contracts;
using Auth.Core;
using Common.Mappers190;
using Common.Web438;
using DataAccess.Service464;
using DataAccess.Validators409;
using Documents.Mappers;
using Export.Processors361;
using Export.Processors79;
using Export.Web479;
using Imaging.Shared115;
using Notifications.Api144;
using Portal.Api;
using Portal.Contracts;
using Portal.Contracts170;
using Reporting.Client422;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Core;

namespace DataAccess.Client
{
    internal interface IDataAccess_Client_Factory5
    {
        /// <summary>Processes the DataAccess_Client_Factory5 operation.</summary>
        void ProcessDataAccess_Client_Factory5();

        /// <summary>Validates the DataAccess_Client_Factory5 state.</summary>
        bool ValidateDataAccess_Client_Factory5();
    }

}