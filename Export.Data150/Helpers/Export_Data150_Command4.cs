using Admin.Service247;
using Auth.Contracts395;
using Auth.Contracts402;
using Auth.Handlers209;
using Auth.Mappers208;
using BatchJobs.Models329;
using Billing.Mappers124;
using Billing.Processors103;
using Billing.Shared149;
using DataAccess.Shared189;
using Export.Processors79;
using GalaxyWorks.Validators;
using Imaging.Service;
using Portal.Processors52;
using Reporting.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Handlers268;
using Utilities.Shared114;

namespace Export.Data150
{
    /// <summary>Immutable data transfer record for Export_Data150_Command4.</summary>
    internal record Export_Data150_Command4(string Value, int Count, DateTime Timestamp);

}