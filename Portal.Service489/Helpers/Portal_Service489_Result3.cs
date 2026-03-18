using Auth.Client;
using Common.Api213;
using Common.Contracts279;
using Common.Service258;
using DataAccess.Shared189;
using Documents.Api132;
using Documents.Processors300;
using Imaging.Mappers;
using Integration.Contracts;
using Integration.Service147;
using Logging.Api316;
using Reporting.Core;
using Reporting.Web345;
using Scheduling.Client;
using Scheduling.Tests;
using Security.Web376;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Service489
{
    public struct Portal_Service489_Result3
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}