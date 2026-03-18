using Admin.Handlers61;
using Admin.Processors;
using Admin.Validators336;
using Auth.Contracts;
using Auth.Models;
using Auth.Shared325;
using Common.Validators430;
using DataAccess.Handlers;
using GalaxyWorks.Handlers385;
using Import.Client64;
using Integration.Handlers;
using Integration.Mappers;
using Integration.Tests;
using Portal.Api51;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Handlers421;
using Workflow.Web59;

namespace Integration.Service
{
    internal struct Integration_Service_Options3
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}