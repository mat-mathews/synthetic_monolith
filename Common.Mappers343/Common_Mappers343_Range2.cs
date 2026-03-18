using Admin.Events306;
using Admin.Models;
using Admin.Processors35;
using Auth.Api;
using Auth.Client271;
using Auth.Handlers209;
using Billing.Api;
using Billing.Client22;
using Billing.Shared;
using Common.Core417;
using Common.Handlers;
using Common.Shared;
using DataAccess.Events283;
using DataAccess.Web;
using Notifications.Handlers;
using Portal.Events151;
using Portal.Validators227;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Api66;

namespace Common.Mappers343
{
    internal struct Common_Mappers343_Range2
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}