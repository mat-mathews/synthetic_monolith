using Admin.Handlers447;
using Admin.Validators;
using Auth.Client;
using Auth.Client249;
using Auth.Contracts;
using Auth.Core;
using Export.Client414;
using GalaxyWorks.Data224;
using GalaxyWorks.Data96;
using GalaxyWorks.Events;
using Imaging.Client;
using Import.Api272;
using Integration.Handlers17;
using Integration.Handlers333;
using Integration.Mappers242;
using Notifications.Web90;
using Scheduling.Client;
using Security.Validators428;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Client113
{
    public struct DataAccess_Client113_Key
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}