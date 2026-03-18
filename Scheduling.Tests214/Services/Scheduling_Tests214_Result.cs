using Admin.Mappers;
using Auth.Api;
using Auth.Events78;
using BatchJobs.Models;
using DataAccess.Processors;
using Documents.Data484;
using Documents.Data68;
using Documents.Tests;
using Export.Processors111;
using Imaging.Data;
using Import.Contracts183;
using Import.Handlers407;
using Logging.Client;
using Notifications.Data;
using Portal.Validators69;
using Scheduling.Api185;
using Scheduling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scheduling.Tests214
{
    public struct Scheduling_Tests214_Result
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}