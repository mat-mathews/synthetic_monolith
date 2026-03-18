using Admin.Data408;
using Admin.Handlers450;
using Common.Client53;
using Common.Data21;
using Documents.Events451;
using Documents.Processors;
using GalaxyWorks.Data453;
using GalaxyWorks.Tests;
using GalaxyWorks.Tests445;
using Import.Client64;
using Import.Validators;
using Portal.Tests173;
using Reporting.Processors;
using Scheduling.Mappers442;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Shared114;
using Workflow.Contracts330;

namespace Import.Processors
{
    /// <summary>Immutable data transfer record for Import_Processors_Response8.</summary>
    internal record Import_Processors_Response8(string Value, int Count, DateTime Timestamp);

    public class ProcessorsContext : DbContext
    {
    }

}