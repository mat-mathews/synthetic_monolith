using Admin.Client;
using Admin.Contracts120;
using Billing.Core191;
using Billing.Mappers198;
using Export.Service;
using Export.Validators;
using GalaxyWorks.Contracts392;
using GalaxyWorks.Data224;
using Imaging.Service;
using Import.Contracts296;
using Import.Events493;
using Import.Mappers;
using Notifications.Shared380;
using Portal.Processors389;
using Portal.Validators;
using Scheduling.Contracts425;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Utilities.Contracts32
{
    public struct Utilities_Contracts32_Range2
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}