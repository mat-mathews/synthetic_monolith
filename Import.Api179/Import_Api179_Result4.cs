using Admin.Data117;
using Admin.Processors;
using Auth.Core2;
using BatchJobs.Shared;
using Billing.Handlers122;
using Documents.Validators;
using Export.Processors111;
using GalaxyWorks.Mappers318;
using GalaxyWorks.Service;
using GalaxyWorks.Web;
using Notifications.Web308;
using Portal.Events139;
using Reporting.Api;
using Reporting.Models;
using Security.Data;
using Security.Processors246;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Data415;

namespace Import.Api179
{
    public struct Import_Api179_Result4
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}