using Admin.Service247;
using Auth.Api143;
using Auth.Client249;
using Auth.Models236;
using Auth.Web;
using Common.Api186;
using Common.Processors142;
using Common.Tests350;
using DataAccess.Client113;
using DataAccess.Shared189;
using Export.Models461;
using Imaging.Events303;
using Import.Data100;
using Portal.Api;
using Portal.Contracts181;
using Security.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Web398;

namespace Export.Events
{
    internal interface IExport_Events_Service4
    {
        /// <summary>Processes the Export_Events_Service4 operation.</summary>
        void ProcessExport_Events_Service4();

        /// <summary>Validates the Export_Events_Service4 state.</summary>
        bool ValidateExport_Events_Service4();
    }

    public class EventsContext : DbContext
    {
    }

}