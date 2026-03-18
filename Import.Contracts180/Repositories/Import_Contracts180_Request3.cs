using Admin.Data;
using Admin.Web4;
using Auth.Core140;
using Auth.Handlers467;
using Auth.Mappers28;
using Auth.Validators87;
using Export.Processors361;
using GalaxyWorks.Events;
using Imaging.Validators;
using Import.Service291;
using Logging.Events;
using Portal.Api;
using Portal.Api352;
using Portal.Contracts;
using Scheduling.Api185;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Contracts32;
using Utilities.Service;
using Utilities.Web398;

namespace Import.Contracts180
{
    /// <summary>Immutable data transfer record for Import_Contracts180_Request3.</summary>
    internal record Import_Contracts180_Request3(string Value, int Count, DateTime Timestamp);

}