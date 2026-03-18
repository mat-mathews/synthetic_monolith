using Admin.Handlers447;
using Admin.Service339;
using Auth.Core140;
using Auth.Core2;
using BatchJobs.Models304;
using BatchJobs.Service;
using BatchJobs.Shared;
using DataAccess.Tests286;
using Import.Handlers354;
using Import.Service265;
using Integration.Validators369;
using Notifications.Data406;
using Portal.Core8;
using Reporting.Handlers;
using Security.Models420;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Contracts228;
using Workflow.Mappers370;

namespace Import.Tests
{
    /// <summary>Immutable data transfer record for Import_Tests_Dto1.</summary>
    internal record Import_Tests_Dto1(string Value, int Count, DateTime Timestamp);

}