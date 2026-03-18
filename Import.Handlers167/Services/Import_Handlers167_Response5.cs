using Admin.Data408;
using Auth.Api;
using Auth.Handlers467;
using DataAccess.Shared486;
using Documents.Service;
using Export.Tests;
using GalaxyWorks.Contracts;
using Imaging.Processors;
using Import.Shared;
using Integration.Api469;
using Logging.Shared315;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Mappers;
using Utilities.Processors;
using Utilities.Shared;
using Workflow.Contracts434;
using Workflow.Data340;
using Workflow.Tests75;

namespace Import.Handlers167
{
    /// <summary>Immutable data transfer record for Import_Handlers167_Response5.</summary>
    public record Import_Handlers167_Response5(string Value, int Count, DateTime Timestamp);

}