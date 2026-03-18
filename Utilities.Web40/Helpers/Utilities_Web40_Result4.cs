using Admin.Handlers450;
using Admin.Models476;
using Auth.Contracts395;
using DataAccess.Handlers482;
using Export.Events276;
using Export.Models;
using GalaxyWorks.Processors;
using Integration.Handlers244;
using Integration.Validators369;
using Logging.Handlers;
using Logging.Mappers;
using Scheduling.Web;
using Scheduling.Web264;
using Security.Core;
using Security.Data;
using Security.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Tests;

namespace Utilities.Web40
{
    public struct Utilities_Web40_Result4
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}