using Admin.Client;
using Admin.Web;
using Auth.Contracts402;
using Auth.Mappers178;
using BatchJobs.Api212;
using Common.Data;
using Common.Events;
using Common.Processors245;
using Common.Tests;
using DataAccess.Service;
using Export.Data6;
using Export.Processors111;
using Logging.Service382;
using Portal.Mappers;
using Portal.Processors389;
using Reporting.Web345;
using Scheduling.Client;
using Security.Shared448;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logging.Models379
{
    internal struct Logging_Models379_Info6
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}