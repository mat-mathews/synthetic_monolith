using Admin.Core121;
using Admin.Data117;
using Admin.Mappers;
using Auth.Service;
using BatchJobs.Core11;
using BatchJobs.Tests270;
using Billing.Validators;
using Billing.Validators305;
using Common.Events280;
using Common.Mappers190;
using Export.Models461;
using Imaging.Handlers;
using Integration.Client;
using Notifications.Data406;
using Notifications.Web;
using Security.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Api66;
using Workflow.Contracts330;

namespace Export.Validators
{
    /// <summary>Immutable data transfer record for Export_Validators_Dto6.</summary>
    public record Export_Validators_Dto6(string Value, int Count, DateTime Timestamp);

}