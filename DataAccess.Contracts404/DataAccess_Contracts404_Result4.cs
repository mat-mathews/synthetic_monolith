using Admin.Api;
using Admin.Data117;
using Admin.Models;
using Auth.Data135;
using Auth.Tests498;
using Billing.Handlers122;
using Common.Api;
using Common.Models381;
using Export.Validators;
using GalaxyWorks.Validators;
using Import.Mappers;
using Integration.Contracts;
using Portal.Processors;
using Security.Api320;
using Security.Shared448;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Handlers421;

namespace DataAccess.Contracts404
{
    internal struct DataAccess_Contracts404_Result4
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}