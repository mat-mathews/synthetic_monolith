using Admin.Core;
using Admin.Mappers;
using Admin.Service339;
using Admin.Tests;
using Auth.Handlers467;
using Auth.Web;
using Billing.Handlers101;
using Documents.Tests106;
using Export.Client414;
using GalaxyWorks.Tests;
using Integration.Mappers242;
using Integration.Service477;
using Reporting.Shared394;
using Scheduling.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Handlers268;
using Workflow.Handlers;

namespace Imaging.Processors
{
    /// <summary>Immutable data transfer record for Imaging_Processors_Command3.</summary>
    internal record Imaging_Processors_Command3(string Value, int Count, DateTime Timestamp);

}