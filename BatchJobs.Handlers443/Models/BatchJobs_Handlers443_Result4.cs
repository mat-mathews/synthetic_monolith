using Admin.Processors;
using Admin.Service;
using Admin.Service456;
using Auth.Contracts402;
using Common.Api;
using Common.Events280;
using Common.Processors245;
using Common.Shared297;
using DataAccess.Processors;
using GalaxyWorks.Contracts94;
using Portal.Processors389;
using Portal.Service;
using Portal.Validators125;
using Portal.Web494;
using Reporting.Web105;
using Scheduling.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Core;
using Utilities.Models;

namespace BatchJobs.Handlers443
{
    internal struct BatchJobs_Handlers443_Result4
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class Handlers443Context : DbContext
    {
    }

}