using Admin.Client;
using Admin.Events;
using Admin.Handlers61;
using Admin.Shared;
using Admin.Validators240;
using Auth.Mappers28;
using Common.Tests;
using DataAccess.Client113;
using Documents.Client;
using Documents.Shared;
using Export.Client414;
using GalaxyWorks.Contracts;
using Imaging.Client331;
using Import.Events493;
using Import.Handlers167;
using Scheduling.Mappers48;
using Security.Api320;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Processors;

namespace Import.Core
{
    /// <summary>Defines the possible states for Import_Core_Type.</summary>
    internal enum Import_Core_Type
    {
        None = 0,
        Active = 1,
        Inactive = 2,
        Pending = 3,
        Processing = 4,
        Completed = 5,
        Failed = 6,
    }

}