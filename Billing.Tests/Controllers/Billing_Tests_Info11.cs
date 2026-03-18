using Admin.Client346;
using Admin.Models476;
using Admin.Service364;
using Admin.Tests10;
using Auth.Handlers281;
using Auth.Mappers;
using Billing.Core;
using Export.Api49;
using Import.Contracts180;
using Import.Mappers56;
using Logging.Api316;
using Logging.Handlers285;
using Notifications.Handlers112;
using Portal.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Web40;
using Workflow.Contracts;
using Workflow.Events327;
using Workflow.Validators;

namespace Billing.Tests
{
    public struct Billing_Tests_Info11
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}