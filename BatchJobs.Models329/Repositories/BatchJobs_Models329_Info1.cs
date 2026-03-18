using Admin.Handlers447;
using Admin.Validators240;
using Admin.Web46;
using Auth.Contracts402;
using Common.Events;
using Common.Shared297;
using Documents.Shared487;
using Imaging.Contracts;
using Import.Client;
using Logging.Mappers;
using Portal.Client;
using Portal.Data;
using Reporting.Processors495;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Mappers;
using Utilities.Mappers97;
using Workflow.Mappers370;

namespace BatchJobs.Models329
{
    internal struct BatchJobs_Models329_Info1
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}