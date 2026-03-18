using Admin.Data117;
using Admin.Events235;
using Admin.Handlers;
using Admin.Processors;
using Billing.Mappers124;
using Common.Core118;
using Common.Events367;
using Documents.Shared487;
using Export.Api12;
using Imaging.Api;
using Import.Events;
using Import.Service291;
using Integration.Handlers17;
using Integration.Handlers333;
using Portal.Validators227;
using Reporting.Events220;
using Scheduling.Models260;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Data;

namespace Common.Contracts279
{
    public struct Common_Contracts279_Range1
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}