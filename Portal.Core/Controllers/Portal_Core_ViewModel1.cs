using Admin.Core;
using Admin.Validators336;
using DataAccess.Tests;
using Documents.Web;
using Export.Client13;
using Export.Models;
using Imaging.Client261;
using Integration.Validators369;
using Logging.Contracts;
using Logging.Contracts373;
using Logging.Core159;
using Reporting.Handlers347;
using Security.Data;
using Security.Shared155;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Api234;
using Utilities.Mappers;

namespace Portal.Core
{
    /// <summary>Immutable data transfer record for Portal_Core_ViewModel1.</summary>
    internal record Portal_Core_ViewModel1(string Value, int Count, DateTime Timestamp);

}