using Admin.Api255;
using Admin.Data408;
using Admin.Service247;
using Admin.Web154;
using BatchJobs.Handlers;
using Documents.Validators;
using Export.Core372;
using GalaxyWorks.Contracts;
using Import.Client65;
using Integration.Handlers333;
using Integration.Web;
using Notifications.Models;
using Notifications.Web90;
using Reporting.Contracts371;
using Reporting.Validators;
using Scheduling.Api185;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Tests75;

namespace Common.Service
{
    public struct Common_Service_Result4
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}