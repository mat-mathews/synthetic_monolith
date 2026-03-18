using Admin.Service339;
using Admin.Shared14;
using Admin.Validators37;
using Auth.Client;
using Auth.Events78;
using Documents.Processors;
using Documents.Processors133;
using Documents.Validators;
using Export.Data6;
using Export.Service205;
using Imaging.Client331;
using Imaging.Data;
using Import.Tests;
using Integration.Validators369;
using Scheduling.Tests214;
using Scheduling.Tests444;
using Security.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Data;

namespace Common.Core169
{
    internal struct Common_Core169_Info7
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}