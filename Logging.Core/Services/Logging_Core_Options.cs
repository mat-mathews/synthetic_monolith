using Admin.Service364;
using Auth.Core2;
using BatchJobs.Core;
using Common.Contracts279;
using Common.Data;
using GalaxyWorks.Events77;
using GalaxyWorks.Shared;
using GalaxyWorks.Validators;
using Import.Service496;
using Integration.Tests86;
using Notifications.Web90;
using Portal.Events139;
using Reporting.Client146;
using Reporting.Web345;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Contracts228;
using Workflow.Events327;

namespace Logging.Core
{
    public struct Logging_Core_Options
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}