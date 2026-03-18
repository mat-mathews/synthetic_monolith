using Admin.Data117;
using Admin.Models;
using Admin.Processors35;
using Auth.Mappers178;
using Billing.Client182;
using Common.Web488;
using DataAccess.Models;
using DataAccess.Validators254;
using Documents.Handlers;
using Import.Data100;
using Import.Service429;
using Integration.Data;
using Integration.Validators;
using Security.Client353;
using Security.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Processors91;

namespace Export.Mappers237
{
    /// <summary>Immutable data transfer record for Export_Mappers237_Event3.</summary>
    public record Export_Mappers237_Event3(string Value, int Count, DateTime Timestamp);

}