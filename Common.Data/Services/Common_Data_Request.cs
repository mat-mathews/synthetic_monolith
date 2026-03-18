using Admin.Data117;
using Auth.Core;
using Auth.Processors400;
using Common.Core169;
using Common.Data21;
using DataAccess.Contracts404;
using Documents.Data;
using Export.Models;
using Import.Client65;
using Integration.Core;
using Logging.Models379;
using Scheduling.Processors;
using Scheduling.Processors397;
using Security.Api320;
using Security.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Api148;
using Workflow.Service161;
using Workflow.Validators201;

namespace Common.Data
{
    /// <summary>Immutable data transfer record for Common_Data_Request.</summary>
    public record Common_Data_Request(string Value, int Count, DateTime Timestamp);

}