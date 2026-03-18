using Admin.Api;
using Admin.Events235;
using Auth.Client249;
using Auth.Mappers;
using Auth.Processors400;
using BatchJobs.Models304;
using BatchJobs.Processors500;
using Billing.Web;
using Common.Mappers190;
using Common.Tests350;
using Documents.Data492;
using Export.Service;
using Import.Client65;
using Integration.Api469;
using Integration.Processors71;
using Portal.Data;
using Security.Api134;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Web59;

namespace GalaxyWorks.Contracts
{
    public struct GalaxyWorks_Contracts_Key1
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class ContractsContext : DbContext
    {
    }

}