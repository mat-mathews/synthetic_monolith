using Admin.Processors35;
using Auth.Mappers;
using Auth.Service;
using Common.Shared;
using Common.Web438;
using Export.Api12;
using Imaging.Models459;
using Imaging.Validators108;
using Import.Contracts;
using Integration.Handlers333;
using Integration.Models;
using Logging.Core;
using Notifications.Validators391;
using Reporting.Web;
using Scheduling.Tests85;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Shared298;

namespace Auth.Processors411
{
    public struct Auth_Processors411_Range10
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class Processors411Context : DbContext
    {
    }

}