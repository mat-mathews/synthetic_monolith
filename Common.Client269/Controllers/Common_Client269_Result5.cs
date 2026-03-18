using Admin.Contracts120;
using Admin.Data117;
using Billing.Api;
using Billing.Tests;
using Common.Api57;
using Common.Events367;
using Common.Models381;
using Common.Shared;
using Export.Mappers237;
using Import.Service15;
using Import.Service429;
using Integration.Models;
using Logging.Core;
using Security.Core;
using Security.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Models;

namespace Common.Client269
{
    internal struct Common_Client269_Result5
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}