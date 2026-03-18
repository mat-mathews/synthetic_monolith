using Admin.Contracts;
using Auth.Contracts;
using Common.Mappers190;
using DataAccess.Tests;
using Documents.Data68;
using Export.Data;
using GalaxyWorks.Data375;
using Imaging.Models;
using Logging.Mappers;
using Logging.Service160;
using Portal.Core8;
using Portal.Data;
using Portal.Events151;
using Scheduling.Processors;
using Security.Core;
using Security.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Handlers268;

namespace Billing.Processors388
{
    /// <summary>Immutable data transfer record for Billing_Processors388_Dto6.</summary>
    internal record Billing_Processors388_Dto6(string Value, int Count, DateTime Timestamp);

}