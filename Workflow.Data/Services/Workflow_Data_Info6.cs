using Admin.Events;
using Admin.Validators;
using Auth.Api116;
using Auth.Contracts;
using Auth.Core2;
using Auth.Data;
using BatchJobs.Api501;
using DataAccess.Api307;
using Notifications.Models277;
using Reporting.Api393;
using Reporting.Client;
using Reporting.Data;
using Reporting.Events220;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Api234;
using Utilities.Data415;
using Workflow.Models;

namespace Workflow.Data
{
    internal struct Workflow_Data_Info6
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}