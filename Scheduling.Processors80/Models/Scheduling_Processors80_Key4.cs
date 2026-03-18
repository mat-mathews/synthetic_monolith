using Admin.Models199;
using Admin.Service339;
using Auth.Api116;
using Auth.Api143;
using Auth.Processors319;
using BatchJobs.Core;
using Billing.Models;
using Common.Events367;
using Imaging.Events303;
using Imaging.Mappers275;
using Reporting.Tests226;
using Scheduling.Tests444;
using Scheduling.Web60;
using Security.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Tests;
using Workflow.Events327;

namespace Scheduling.Processors80
{
    public struct Scheduling_Processors80_Key4
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class Processors80Context : DbContext
    {
    }

}