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
    /// <summary>Immutable data transfer record for GalaxyWorks_Contracts_Request5.</summary>
    internal record GalaxyWorks_Contracts_Request5(string Value, int Count, DateTime Timestamp);

}