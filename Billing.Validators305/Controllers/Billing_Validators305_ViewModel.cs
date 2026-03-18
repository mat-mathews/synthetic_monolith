using Admin.Contracts120;
using Admin.Events235;
using Admin.Events306;
using Auth.Api116;
using Auth.Events;
using Billing.Mappers124;
using Common.Processors;
using Documents.Data492;
using Imaging.Client261;
using Imaging.Shared;
using Logging.Data;
using Reporting.Handlers347;
using Reporting.Web;
using Security.Events288;
using Security.Models18;
using Security.Shared;
using Security.Shared365;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Handlers268;

namespace Billing.Validators305
{
    /// <summary>Immutable data transfer record for Billing_Validators305_ViewModel.</summary>
    internal record Billing_Validators305_ViewModel(string Value, int Count, DateTime Timestamp);

}