using Admin.Api255;
using Admin.Client346;
using Admin.Tests10;
using BatchJobs.Tests270;
using Common.Client;
using Common.Processors245;
using Common.Service258;
using DataAccess.Api307;
using DataAccess.Core;
using DataAccess.Tests;
using Documents.Models;
using Export.Core;
using Imaging.Mappers93;
using Import.Handlers167;
using Integration.Data175;
using Integration.Service401;
using Portal.Validators227;
using Reporting.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration.Service107
{
    /// <summary>Defines the possible states for Integration_Service107_Status.</summary>
    public enum Integration_Service107_Status
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