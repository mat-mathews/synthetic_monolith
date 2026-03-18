using Admin.Contracts;
using Admin.Core;
using Admin.Validators37;
using Admin.Web4;
using Auth.Client249;
using Auth.Contracts402;
using BatchJobs.Handlers443;
using Common.Events;
using Documents.Processors;
using Export.Api49;
using GalaxyWorks.Events256;
using GalaxyWorks.Shared;
using Imaging.Tests;
using Import.Tests119;
using Integration.Handlers333;
using Logging.Api;
using Logging.Service;
using Notifications.Models277;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reporting.Contracts
{
    internal struct Reporting_Contracts_Result
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}