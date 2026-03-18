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
    /// <summary>Defines the possible states for GalaxyWorks_Models_Category2.</summary>
    public enum GalaxyWorks_Models_Category2
    {
        None = 0,
        Active = 1,
        Inactive = 2,
        Pending = 3,
        Processing = 4,
        Completed = 5,
        Failed = 6,
    }

}