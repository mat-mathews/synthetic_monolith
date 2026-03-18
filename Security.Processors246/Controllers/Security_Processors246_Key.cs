using Admin.Contracts120;
using Admin.Handlers;
using Admin.Validators;
using Admin.Web4;
using Auth.Client271;
using Auth.Mappers206;
using Billing.Validators174;
using Documents.Contracts;
using GalaxyWorks.Data224;
using Imaging.Models;
using Imaging.Validators;
using Import.Processors;
using Import.Shared;
using Integration.Service401;
using Notifications.Mappers;
using Portal.Api123;
using Reporting.Service207;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Models;

namespace Security.Processors246
{
    internal struct Security_Processors246_Key
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}