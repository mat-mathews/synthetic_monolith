using Admin.Core121;
using Admin.Processors;
using Auth.Mappers178;
using DataAccess.Contracts203;
using Documents.Data490;
using Documents.Models;
using Export.Handlers;
using Export.Processors111;
using GalaxyWorks.Models;
using Imaging.Shared115;
using Imaging.Validators;
using Import.Validators;
using Integration.Tests86;
using Notifications.Validators;
using Portal.Web158;
using Scheduling.Core273;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Validators;

namespace Scheduling.Core
{
    /// <summary>Immutable data transfer record for Scheduling_Core_Event10.</summary>
    internal record Scheduling_Core_Event10(string Value, int Count, DateTime Timestamp);

    public class CoreContext : DbContext
    {
    }

}