using Admin.Validators;
using Auth.Client271;
using Common.Client;
using Common.Data21;
using Common.Models;
using Documents.Service;
using GalaxyWorks.Client366;
using GalaxyWorks.Data153;
using Imaging.Service;
using Integration.Service147;
using Logging.Web;
using Portal.Mappers233;
using Security.Contracts;
using Security.Validators418;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Contracts330;
using Workflow.Tests222;

namespace Integration.Handlers244
{
    /// <summary>Immutable data transfer record for Integration_Handlers244_Request1.</summary>
    internal record Integration_Handlers244_Request1(string Value, int Count, DateTime Timestamp);

}