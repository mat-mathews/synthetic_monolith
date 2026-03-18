using Admin.Core;
using Auth.Data135;
using Auth.Events;
using Auth.Shared325;
using BatchJobs.Data;
using BatchJobs.Events435;
using BatchJobs.Handlers;
using DataAccess.Client82;
using GalaxyWorks.Client366;
using Imaging.Service;
using Logging.Data29;
using Logging.Handlers285;
using Portal.Api;
using Portal.Processors;
using Reporting.Contracts;
using Security.Contracts238;
using Security.Tests360;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Security.Contracts
{
    public struct Security_Contracts_Options10
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}