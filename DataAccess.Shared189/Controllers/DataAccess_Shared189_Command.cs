using Admin.Api255;
using Admin.Client177;
using Admin.Core;
using Auth.Models236;
using BatchJobs.Client267;
using BatchJobs.Validators;
using Billing.Contracts44;
using Common.Client269;
using Common.Models381;
using Common.Shared95;
using DataAccess.Tests286;
using GalaxyWorks.Mappers318;
using Import.Tests119;
using Integration.Handlers17;
using Portal.Contracts181;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Client;
using Workflow.Contracts434;

namespace DataAccess.Shared189
{
    /// <summary>Immutable data transfer record for DataAccess_Shared189_Command.</summary>
    internal record DataAccess_Shared189_Command(string Value, int Count, DateTime Timestamp);

}