using Admin.Api;
using Admin.Contracts120;
using Auth.Client271;
using Auth.Mappers208;
using Auth.Service;
using BatchJobs.Contracts399;
using BatchJobs.Tests270;
using Billing.Service432;
using Common.Shared297;
using DataAccess.Handlers;
using Documents.Shared;
using Imaging.Data;
using Imaging.Handlers;
using Portal.Models;
using Scheduling.Client;
using Scheduling.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Processors;

namespace Utilities.Mappers232
{
    internal struct Utilities_Mappers232_Options5
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}