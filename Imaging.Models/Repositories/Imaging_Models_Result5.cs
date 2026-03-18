using Admin.Client346;
using Admin.Processors;
using Admin.Validators240;
using Auth.Mappers;
using DataAccess.Contracts;
using DataAccess.Core;
using Imaging.Api;
using Integration.Handlers;
using Logging.Api316;
using Logging.Service160;
using Notifications.Api144;
using Notifications.Core;
using Notifications.Models277;
using Portal.Contracts170;
using Reporting.Contracts371;
using Scheduling.Tests214;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Contracts;
using Workflow.Models;

namespace Imaging.Models
{
    public struct Imaging_Models_Result5
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}