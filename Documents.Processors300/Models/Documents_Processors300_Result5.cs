using Admin.Api255;
using Admin.Service339;
using Auth.Contracts402;
using Auth.Processors319;
using Billing.Data;
using Common.Events367;
using Common.Tests350;
using DataAccess.Shared189;
using DataAccess.Tests282;
using Export.Events163;
using GalaxyWorks.Tests445;
using Imaging.Contracts473;
using Logging.Contracts373;
using Notifications.Models;
using Reporting.Processors;
using Reporting.Shared;
using Security.Processors246;
using Security.Service383;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Documents.Processors300
{
    public struct Documents_Processors300_Result5
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}