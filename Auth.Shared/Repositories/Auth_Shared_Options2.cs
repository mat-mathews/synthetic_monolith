using Admin.Api;
using Admin.Processors;
using Admin.Validators336;
using Auth.Contracts;
using Auth.Events5;
using Auth.Mappers28;
using Common.Shared297;
using Documents.Client;
using Export.Web479;
using Imaging.Events;
using Import.Client7;
using Notifications.Models466;
using Notifications.Shared396;
using Scheduling.Core273;
using Scheduling.Processors335;
using Security.Handlers162;
using Security.Handlers460;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Contracts330;

namespace Auth.Shared
{
    internal struct Auth_Shared_Options2
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}