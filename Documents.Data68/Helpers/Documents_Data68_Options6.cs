using Admin.Data117;
using BatchJobs.Client267;
using Billing.Web;
using Common.Events367;
using DataAccess.Contracts404;
using Export.Contracts;
using Export.Core;
using Export.Web210;
using Imaging.Client261;
using Imaging.Core204;
using Integration.Handlers244;
using Portal.Contracts;
using Portal.Events;
using Scheduling.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Models;
using Utilities.Tests;

namespace Documents.Data68
{
    internal struct Documents_Data68_Options6
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}