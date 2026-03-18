using Admin.Client346;
using Admin.Handlers;
using Auth.Events78;
using Billing.Client182;
using Billing.Mappers;
using Common.Client53;
using Common.Data;
using Common.Service258;
using Common.Validators50;
using DataAccess.Events;
using Documents.Processors300;
using Export.Mappers;
using Imaging.Web;
using Import.Api272;
using Scheduling.Shared39;
using Security.Client353;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Shared298;

namespace Import.Web
{
    internal struct Import_Web_Point4
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}