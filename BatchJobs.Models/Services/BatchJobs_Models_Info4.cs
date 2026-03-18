using Admin.Client;
using Admin.Models199;
using Auth.Core;
using Auth.Mappers208;
using Common.Client269;
using Common.Events280;
using Common.Shared;
using Documents.Data484;
using GalaxyWorks.Data153;
using Integration.Contracts290;
using Integration.Core;
using Integration.Handlers244;
using Portal.Service378;
using Portal.Web;
using Reporting.Models;
using Security.Api320;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BatchJobs.Models
{
    internal struct BatchJobs_Models_Info4
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}