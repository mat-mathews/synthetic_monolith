using Admin.Models199;
using Admin.Processors;
using Admin.Service364;
using Auth.Data135;
using Auth.Handlers;
using BatchJobs.Api501;
using Billing.Data;
using Common.Core118;
using DataAccess.Contracts404;
using Documents.Data;
using Imaging.Models184;
using Integration.Service477;
using Logging.Api;
using Logging.Client405;
using Logging.Shared;
using Security.Processors;
using Security.Service383;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scheduling.Web19
{
    internal struct Scheduling_Web19_Info5
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}