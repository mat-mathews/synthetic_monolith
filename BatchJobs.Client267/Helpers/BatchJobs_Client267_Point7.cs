using Admin.Web;
using Auth.Handlers;
using Common.Mappers343;
using Export.Core;
using Export.Events;
using Export.Web210;
using GalaxyWorks.Handlers;
using Imaging.Contracts;
using Import.Processors472;
using Notifications.Web90;
using Reporting.Client146;
using Reporting.Validators;
using Scheduling.Handlers;
using Security.Client353;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Api66;
using Utilities.Processors91;
using Utilities.Web398;

namespace BatchJobs.Client267
{
    internal struct BatchJobs_Client267_Point7
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}