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
    /// <summary>Defines the possible states for Common_Data_Type7.</summary>
    public enum Common_Data_Type7
    {
        None = 0,
        Active = 1,
        Inactive = 2,
        Pending = 3,
        Processing = 4,
        Completed = 5,
        Failed = 6,
    }

}