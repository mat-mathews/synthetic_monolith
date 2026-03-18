using Auth.Api143;
using Auth.Client38;
using Auth.Processors411;
using Billing.Data;
using Billing.Validators;
using Documents.Validators;
using Export.Api49;
using Export.Mappers;
using GalaxyWorks.Service;
using Import.Client65;
using Import.Data100;
using Integration.Events;
using Notifications.Data;
using Portal.Api51;
using Scheduling.Client187;
using Scheduling.Contracts425;
using Security.Shared448;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Import.Mappers56
{
    /// <summary>Immutable data transfer record for Import_Mappers56_Event2.</summary>
    internal record Import_Mappers56_Event2(string Value, int Count, DateTime Timestamp);

}