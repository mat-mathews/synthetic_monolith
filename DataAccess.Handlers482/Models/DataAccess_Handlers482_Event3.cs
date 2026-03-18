using Admin.Client;
using Admin.Handlers;
using Admin.Models;
using Admin.Service;
using Common.Validators50;
using DataAccess.Tests282;
using Export.Events163;
using Export.Service30;
using Imaging.Mappers;
using Imaging.Models;
using Import.Api179;
using Integration.Service147;
using Logging.Models379;
using Portal.Service378;
using Portal.Validators69;
using Scheduling.Web60;
using Security.Shared448;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Handlers482
{
    /// <summary>Immutable data transfer record for DataAccess_Handlers482_Event3.</summary>
    internal record DataAccess_Handlers482_Event3(string Value, int Count, DateTime Timestamp);

}