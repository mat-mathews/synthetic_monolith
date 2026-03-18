using Admin.Service339;
using Admin.Tests10;
using Billing.Events;
using Billing.Processors103;
using DataAccess.Events283;
using Documents.Service;
using GalaxyWorks.Mappers318;
using Import.Handlers;
using Import.Handlers167;
using Integration.Validators369;
using Notifications.Mappers55;
using Portal.Data266;
using Portal.Service;
using Portal.Tests;
using Reporting.Data;
using Reporting.Events188;
using Scheduling.Processors397;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Api307
{
    /// <summary>Immutable data transfer record for DataAccess_Api307_Dto1.</summary>
    public record DataAccess_Api307_Dto1(string Value, int Count, DateTime Timestamp);

    public class Api307Context : DbContext
    {
    }

}