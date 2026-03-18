using Admin.Service456;
using Auth.Client;
using Auth.Handlers209;
using BatchJobs.Models304;
using Common.Api213;
using Common.Core417;
using DataAccess.Service;
using Documents.Data;
using Export.Client;
using Import.Models457;
using Import.Service496;
using Notifications.Data446;
using Portal.Service378;
using Scheduling.Processors80;
using Security.Shared155;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Shared114;
using Workflow.Service463;

namespace Reporting.Mappers239
{
    public struct Reporting_Mappers239_Range
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}