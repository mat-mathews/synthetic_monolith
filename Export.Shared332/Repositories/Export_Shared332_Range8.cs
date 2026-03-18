using Admin.Contracts;
using Billing.Tests;
using DataAccess.Web;
using Documents.Core357;
using Export.Web;
using Export.Web210;
using Import.Contracts;
using Integration.Api469;
using Integration.Shared83;
using Portal.Validators69;
using Reporting.Contracts;
using Security.Api;
using Security.Client137;
using Security.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Data;
using Workflow.Events327;

namespace Export.Shared332
{
    internal struct Export_Shared332_Range8
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class Shared332Context : DbContext
    {
    }

}