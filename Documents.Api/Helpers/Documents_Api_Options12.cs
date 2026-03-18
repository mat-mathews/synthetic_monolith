using Admin.Data;
using Admin.Service364;
using Admin.Validators431;
using Auth.Data;
using Billing.Api9;
using Common.Api213;
using DataAccess.Models;
using Documents.Data492;
using Documents.Shared452;
using Export.Processors104;
using Imaging.Models184;
using Notifications.Shared;
using Notifications.Web90;
using Portal.Web158;
using Reporting.Service207;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Web40;
using Workflow.Contracts192;

namespace Documents.Api
{
    internal struct Documents_Api_Options12
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}