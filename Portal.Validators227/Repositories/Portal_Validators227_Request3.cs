using Admin.Client;
using Admin.Events235;
using Admin.Validators336;
using Admin.Web46;
using Auth.Events78;
using Billing.Mappers225;
using Common.Api57;
using Common.Core169;
using Documents.Data;
using Imaging.Events303;
using Import.Contracts183;
using Import.Models457;
using Import.Service429;
using Import.Shared;
using Integration.Processors241;
using Portal.Service;
using Security.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Validators227
{
    /// <summary>Immutable data transfer record for Portal_Validators227_Request3.</summary>
    internal record Portal_Validators227_Request3(string Value, int Count, DateTime Timestamp);

}