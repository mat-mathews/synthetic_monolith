using Admin.Data465;
using Admin.Handlers61;
using Admin.Service339;
using Auth.Mappers;
using BatchJobs.Events435;
using Billing.Mappers;
using Imaging.Tests328;
using Logging.Mappers157;
using Notifications.Data348;
using Notifications.Models;
using Notifications.Web;
using Portal.Processors52;
using Scheduling.Processors337;
using Scheduling.Service;
using Scheduling.Shared;
using Scheduling.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Processors;
using Workflow.Shared298;

namespace Reporting.Tests226
{
    internal struct Reporting_Tests226_Result4
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class Tests226Context : DbContext
    {
    }

}