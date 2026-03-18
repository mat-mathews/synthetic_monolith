using Admin.Contracts120;
using Admin.Handlers;
using Admin.Service;
using Admin.Validators;
using Admin.Validators431;
using Admin.Web4;
using Auth.Processors319;
using Auth.Validators87;
using Billing.Client;
using Billing.Mappers225;
using Common.Api186;
using DataAccess.Web;
using Export.Shared;
using GalaxyWorks.Data375;
using Imaging.Handlers;
using Import.Shared;
using Scheduling.Models342;
using Security.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BatchJobs.Contracts
{
    internal struct BatchJobs_Contracts_Range2
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}