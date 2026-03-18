using Admin.Api;
using Admin.Validators240;
using Auth.Models236;
using Billing.Client;
using Common.Contracts;
using Common.Validators50;
using DataAccess.Tests;
using Documents.Data490;
using Documents.Processors300;
using Export.Service205;
using Export.Web210;
using Logging.Events;
using Logging.Models;
using Scheduling.Api185;
using Scheduling.Validators;
using Scheduling.Web221;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Api234;

namespace Notifications.Tests299
{
    /// <summary>Immutable data transfer record for Notifications_Tests299_Dto.</summary>
    internal record Notifications_Tests299_Dto(string Value, int Count, DateTime Timestamp);

}