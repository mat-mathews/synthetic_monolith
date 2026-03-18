using Admin.Mappers;
using Admin.Validators;
using Auth.Data;
using Billing.Models;
using Common.Validators50;
using DataAccess.Processors;
using Export.Contracts;
using GalaxyWorks.Validators;
using Import.Client356;
using Logging.Core;
using Notifications.Data;
using Portal.Contracts181;
using Reporting.Api287;
using Reporting.Validators;
using Scheduling.Handlers43;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Handlers;

namespace Security.Service
{
    internal struct Security_Service_Point
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}