using Admin.Api255;
using Admin.Validators37;
using Auth.Api116;
using Common.Client;
using Common.Mappers190;
using Documents.Api;
using Documents.Core357;
using Documents.Tests458;
using GalaxyWorks.Contracts485;
using GalaxyWorks.Tests;
using Notifications.Service165;
using Portal.Contracts170;
using Portal.Core8;
using Scheduling.Events;
using Security.Models18;
using Security.Web376;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GalaxyWorks.Api390
{
    /// <summary>Defines the possible states for GalaxyWorks_Api390_Category5.</summary>
    internal enum GalaxyWorks_Api390_Category5
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