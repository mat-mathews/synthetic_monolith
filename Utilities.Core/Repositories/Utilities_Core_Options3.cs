using Admin.Handlers450;
using Auth.Contracts402;
using Billing.Contracts;
using Common.Mappers190;
using DataAccess.Validators409;
using Export.Web229;
using Import.Handlers407;
using Import.Models457;
using Integration.Handlers244;
using Logging.Models379;
using Reporting.Events188;
using Security.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Api;
using Utilities.Validators;
using Workflow.Contracts192;
using Workflow.Service161;

namespace Utilities.Core
{
    internal struct Utilities_Core_Options3
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}