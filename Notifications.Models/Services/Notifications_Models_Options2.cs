using Admin.Events306;
using Billing.Contracts44;
using Billing.Tests;
using Common.Web488;
using Documents.Data490;
using Export.Api49;
using GalaxyWorks.Service;
using Imaging.Core204;
using Import.Client64;
using Import.Data193;
using Integration.Mappers242;
using Logging.Shared;
using Notifications.Handlers;
using Portal.Service231;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Api387;
using Utilities.Contracts24;

namespace Notifications.Models
{
    public struct Notifications_Models_Options2
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}