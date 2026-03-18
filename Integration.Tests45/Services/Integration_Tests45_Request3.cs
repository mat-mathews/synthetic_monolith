using Admin.Contracts120;
using Admin.Service364;
using Admin.Shared310;
using Admin.Tests;
using Auth.Processors400;
using Common.Api;
using Common.Events;
using Common.Validators430;
using DataAccess.Contracts;
using DataAccess.Tests;
using Documents.Data490;
using Documents.Service215;
using Export.Contracts;
using GalaxyWorks.Models219;
using Portal.Api;
using Portal.Tests;
using Reporting.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration.Tests45
{
    /// <summary>Immutable data transfer record for Integration_Tests45_Request3.</summary>
    public record Integration_Tests45_Request3(string Value, int Count, DateTime Timestamp);

}