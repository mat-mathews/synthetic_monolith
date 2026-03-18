using Admin.Events;
using Auth.Api;
using Auth.Core140;
using Common.Processors142;
using Export.Core386;
using Export.Mappers;
using Imaging.Mappers93;
using Import.Client64;
using Import.Processors412;
using Portal.Validators69;
using Reporting.Processors326;
using Reporting.Shared394;
using Scheduling.Models342;
using Scheduling.Models441;
using Scheduling.Web19;
using Security.Contracts;
using Security.Tests360;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billing.Service
{
    /// <summary>Immutable data transfer record for Billing_Service_ViewModel2.</summary>
    internal record Billing_Service_ViewModel2(string Value, int Count, DateTime Timestamp);

}