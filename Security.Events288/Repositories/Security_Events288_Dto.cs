using Admin.Contracts;
using Admin.Tests10;
using Admin.Validators431;
using BatchJobs.Processors500;
using Common.Mappers343;
using DataAccess.Service464;
using Documents.Service215;
using Export.Api;
using Imaging.Mappers93;
using Import.Models457;
using Integration.Events301;
using Notifications.Contracts;
using Notifications.Data;
using Scheduling.Processors397;
using Scheduling.Tests;
using Security.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Security.Events288
{
    /// <summary>Immutable data transfer record for Security_Events288_Dto.</summary>
    public record Security_Events288_Dto(string Value, int Count, DateTime Timestamp);

}