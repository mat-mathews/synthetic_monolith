using Admin.Client177;
using Admin.Handlers450;
using Admin.Processors;
using Admin.Web46;
using Billing.Mappers124;
using Common.Api213;
using DataAccess.Api341;
using Documents.Shared427;
using GalaxyWorks.Handlers;
using Imaging.Events303;
using Integration.Service477;
using Integration.Validators;
using Portal.Service378;
using Reporting.Shared;
using Security.Models420;
using Security.Shared155;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Handlers421;
using Workflow.Shared298;

namespace Portal.Events139
{
    public struct Portal_Events139_Point10
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}