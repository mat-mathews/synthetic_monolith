using Admin.Api;
using Admin.Models476;
using Admin.Service;
using Common.Processors142;
using Documents.Validators;
using Export.Api;
using Export.Data150;
using Export.Handlers202;
using Export.Models461;
using Export.Shared;
using Import.Shared;
using Integration.Handlers333;
using Logging.Models436;
using Portal.Contracts170;
using Reporting.Service207;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Processors;

namespace Notifications.Validators391
{
    internal struct Notifications_Validators391_Range5
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}