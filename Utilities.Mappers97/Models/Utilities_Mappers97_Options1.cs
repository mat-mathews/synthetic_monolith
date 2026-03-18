using Admin.Validators431;
using Auth.Client;
using Auth.Events;
using BatchJobs.Processors410;
using DataAccess.Handlers;
using Export.Events276;
using GalaxyWorks.Mappers;
using Imaging.Validators108;
using Logging.Client405;
using Notifications.Mappers55;
using Notifications.Service165;
using Notifications.Validators391;
using Scheduling.Models342;
using Security.Models284;
using Security.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Client;

namespace Utilities.Mappers97
{
    public struct Utilities_Mappers97_Options1
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}