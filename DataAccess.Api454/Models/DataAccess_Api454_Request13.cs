using Admin.Client346;
using Auth.Api;
using Auth.Mappers206;
using Billing.Validators;
using Common.Processors;
using DataAccess.Shared;
using Documents.Service;
using GalaxyWorks.Data224;
using GalaxyWorks.Service293;
using Import.Contracts131;
using Integration.Validators;
using Portal.Handlers26;
using Reporting.Shared394;
using Scheduling.Web60;
using Security.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Validators138;

namespace DataAccess.Api454
{
    /// <summary>Immutable data transfer record for DataAccess_Api454_Request13.</summary>
    public record DataAccess_Api454_Request13(string Value, int Count, DateTime Timestamp);

}