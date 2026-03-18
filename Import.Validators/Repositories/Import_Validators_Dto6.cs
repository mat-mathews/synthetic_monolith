using Admin.Contracts;
using Admin.Core121;
using Admin.Handlers;
using Admin.Service339;
using BatchJobs.Models304;
using Common.Processors;
using Export.Data344;
using GalaxyWorks.Service293;
using Imaging.Contracts89;
using Import.Models;
using Integration.Handlers423;
using Portal.Client;
using Portal.Contracts170;
using Portal.Handlers26;
using Security.Contracts72;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Contracts24;
using Utilities.Handlers268;

namespace Import.Validators
{
    /// <summary>Immutable data transfer record for Import_Validators_Dto6.</summary>
    public record Import_Validators_Dto6(string Value, int Count, DateTime Timestamp);

}