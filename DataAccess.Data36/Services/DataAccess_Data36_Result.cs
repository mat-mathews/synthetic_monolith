using Admin.Client177;
using Admin.Data117;
using Admin.Events;
using Admin.Web46;
using Auth.Client249;
using Auth.Mappers;
using Auth.Models23;
using DataAccess.Models;
using DataAccess.Web200;
using Export.Events163;
using Export.Service;
using Import.Api272;
using Scheduling.Contracts;
using Security.Client137;
using Security.Data278;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Handlers;
using Workflow.Core;
using Workflow.Validators138;

namespace DataAccess.Data36
{
    internal struct DataAccess_Data36_Result
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}