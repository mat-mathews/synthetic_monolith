using Admin.Web154;
using Auth.Core;
using Auth.Tests498;
using BatchJobs.Contracts;
using Billing.Processors388;
using DataAccess.Shared;
using Documents.Web;
using Export.Web130;
using Imaging.Events;
using Import.Client356;
using Import.Handlers;
using Import.Mappers;
using Integration.Events;
using Portal.Events151;
using Scheduling.Web264;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Events;

namespace Security.Processors295
{
    internal struct Security_Processors295_Key
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}