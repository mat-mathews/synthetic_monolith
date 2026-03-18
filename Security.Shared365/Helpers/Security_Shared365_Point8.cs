using Admin.Api255;
using Admin.Mappers;
using Auth.Events78;
using Billing.Service;
using Common.Contracts279;
using DataAccess.Events;
using DataAccess.Service464;
using Documents.Api439;
using Export.Client13;
using GalaxyWorks.Events256;
using Imaging.Core204;
using Integration.Processors;
using Reporting.Handlers;
using Scheduling.Api3;
using Scheduling.Tests85;
using Security.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Processors;

namespace Security.Shared365
{
    public struct Security_Shared365_Point8
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}