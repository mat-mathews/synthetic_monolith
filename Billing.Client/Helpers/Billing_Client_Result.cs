using Admin.Models;
using Auth.Events;
using Auth.Models236;
using Auth.Web;
using Billing.Contracts44;
using Billing.Data;
using DataAccess.Validators;
using Export.Core168;
using Import.Events493;
using Import.Service265;
using Import.Tests;
using Integration.Events;
using Reporting.Client422;
using Scheduling.Api185;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Core;
using Utilities.Data415;

namespace Billing.Client
{
    internal struct Billing_Client_Result
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}