using Admin.Contracts120;
using Admin.Core;
using Admin.Models;
using Admin.Service247;
using Admin.Service339;
using Billing.Service432;
using DataAccess.Api341;
using Documents.Api132;
using Documents.Service471;
using GalaxyWorks.Data453;
using GalaxyWorks.Models219;
using Imaging.Events303;
using Logging.Contracts373;
using Notifications.Processors;
using Reporting.Processors326;
using Security.Models18;
using Security.Service383;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Validators;

namespace Integration.Mappers242
{
    public struct Integration_Mappers242_Options4
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}