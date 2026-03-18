using Admin.Data117;
using Admin.Processors;
using Admin.Web4;
using Auth.Client;
using Auth.Core;
using Auth.Shared325;
using BatchJobs.Mappers;
using DataAccess.Validators409;
using Documents.Data490;
using Export.Events;
using GalaxyWorks.Data263;
using Imaging.Client;
using Import.Data193;
using Integration.Processors241;
using Integration.Shared83;
using Notifications.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Api66;

namespace Billing.Contracts44
{
    /// <summary>Immutable data transfer record for Billing_Contracts44_Command.</summary>
    internal record Billing_Contracts44_Command(string Value, int Count, DateTime Timestamp);

    public class Contracts44Context : DbContext
    {
    }

}