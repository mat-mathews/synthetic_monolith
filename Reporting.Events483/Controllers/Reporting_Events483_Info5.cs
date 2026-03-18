using Admin.Api255;
using Admin.Client;
using Admin.Shared;
using Admin.Web;
using Auth.Api143;
using Billing.Processors103;
using Billing.Shared149;
using Common.Data;
using Documents.Events451;
using Documents.Validators102;
using Import.Validators;
using Portal.Contracts;
using Reporting.Api;
using Scheduling.Api;
using Scheduling.Data54;
using Scheduling.Web19;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Core;
using Workflow.Models253;

namespace Reporting.Events483
{
    internal struct Reporting_Events483_Info5
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}