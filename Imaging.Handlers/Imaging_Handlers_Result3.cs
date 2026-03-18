using Auth.Contracts;
using BatchJobs.Handlers443;
using BatchJobs.Validators;
using Billing.Handlers101;
using DataAccess.Validators254;
using Documents.Service;
using Documents.Shared334;
using Documents.Validators;
using Integration.Processors241;
using Notifications.Core;
using Notifications.Service;
using Portal.Validators125;
using Reporting.Contracts371;
using Scheduling.Handlers;
using Security.Core243;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Data340;

namespace Imaging.Handlers
{
    internal struct Imaging_Handlers_Result3
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}