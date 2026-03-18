using Admin.Mappers;
using Auth.Contracts;
using Documents.Data484;
using Documents.Validators102;
using GalaxyWorks.Api;
using GalaxyWorks.Contracts;
using GalaxyWorks.Mappers403;
using Notifications.Tests299;
using Portal.Api51;
using Portal.Data216;
using Portal.Events;
using Scheduling.Api;
using Scheduling.Processors;
using Security.Core243;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Api66;
using Utilities.Processors440;
using Workflow.Tests75;

namespace GalaxyWorks.Models
{
    public struct GalaxyWorks_Models_Range7
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}