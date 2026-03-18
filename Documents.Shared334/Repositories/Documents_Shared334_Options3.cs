using Admin.Web154;
using Auth.Core2;
using Billing.Validators;
using Common.Mappers;
using Common.Processors142;
using GalaxyWorks.Shared437;
using Import.Contracts183;
using Portal.Handlers;
using Portal.Processors;
using Scheduling.Events;
using Security.Api;
using Security.Client353;
using Security.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Contracts24;
using Utilities.Processors91;
using Utilities.Web;

namespace Documents.Shared334
{
    internal struct Documents_Shared334_Options3
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}