using Auth.Contracts395;
using Auth.Events5;
using Auth.Mappers208;
using Auth.Models23;
using Billing.Contracts;
using Common.Contracts279;
using DataAccess.Shared;
using Documents.Processors;
using Export.Web130;
using Export.Web479;
using Imaging.Events;
using Notifications.Handlers112;
using Portal.Handlers;
using Scheduling.Mappers48;
using Scheduling.Processors397;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Api;
using Utilities.Validators;

namespace Utilities.Tests
{
    /// <summary>Immutable data transfer record for Utilities_Tests_Dto4.</summary>
    public record Utilities_Tests_Dto4(string Value, int Count, DateTime Timestamp);

}