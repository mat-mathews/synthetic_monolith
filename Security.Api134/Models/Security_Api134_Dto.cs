using Admin.Events;
using Admin.Mappers324;
using Admin.Service364;
using Admin.Tests;
using BatchJobs.Tests270;
using Documents.Data484;
using Documents.Web;
using GalaxyWorks.Processors16;
using Import.Client7;
using Portal.Processors52;
using Portal.Service378;
using Reporting.Api;
using Reporting.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Core;
using Utilities.Processors;
using Workflow.Validators;
using Workflow.Web;

namespace Security.Api134
{
    /// <summary>Immutable data transfer record for Security_Api134_Dto.</summary>
    internal record Security_Api134_Dto(string Value, int Count, DateTime Timestamp);

    public class Api134Context : DbContext
    {
    }

}