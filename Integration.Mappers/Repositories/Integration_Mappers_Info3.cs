using Admin.Service;
using Admin.Service456;
using Auth.Contracts;
using Documents.Shared334;
using Imaging.Web172;
using Import.Contracts296;
using Import.Shared;
using Logging.Contracts;
using Notifications.Api;
using Notifications.Handlers;
using Notifications.Mappers55;
using Notifications.Service;
using Reporting.Processors495;
using Security.Contracts;
using Security.Processors295;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Events;

namespace Integration.Mappers
{
    internal struct Integration_Mappers_Info3
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}