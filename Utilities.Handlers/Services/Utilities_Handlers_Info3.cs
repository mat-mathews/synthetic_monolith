using Auth.Core;
using Auth.Core140;
using Auth.Mappers206;
using Billing.Service;
using Billing.Web;
using Common.Validators430;
using Documents.Core;
using Documents.Validators;
using Integration.Handlers;
using Portal.Processors52;
using Scheduling.Processors335;
using Security.Events;
using Security.Processors295;
using Security.Shared365;
using Security.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Processors;
using Workflow.Validators138;

namespace Utilities.Handlers
{
    public struct Utilities_Handlers_Info3
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}