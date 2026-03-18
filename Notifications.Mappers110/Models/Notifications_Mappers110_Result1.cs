using Admin.Api;
using Admin.Handlers;
using Admin.Web4;
using Auth.Core;
using Billing.Handlers122;
using DataAccess.Shared189;
using Documents.Core357;
using Export.Mappers237;
using Export.Shared;
using Export.Web229;
using GalaxyWorks.Shared;
using GalaxyWorks.Tests445;
using Imaging.Mappers275;
using Security.Processors;
using Security.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Events;
using Workflow.Service161;
using Workflow.Service463;

namespace Notifications.Mappers110
{
    internal struct Notifications_Mappers110_Result1
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}