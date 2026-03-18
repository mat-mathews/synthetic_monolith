using Admin.Contracts;
using Admin.Shared14;
using Admin.Shared363;
using Auth.Contracts395;
using Auth.Contracts402;
using Auth.Handlers;
using Common.Api186;
using DataAccess.Shared189;
using Documents.Core;
using Documents.Shared;
using GalaxyWorks.Contracts392;
using GalaxyWorks.Service;
using Import.Client64;
using Notifications.Web308;
using Portal.Events;
using Portal.Models413;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Api;
using Workflow.Handlers;

namespace Integration.Service147
{
    public struct Integration_Service147_Key4
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}