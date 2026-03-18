using Auth.Contracts395;
using Auth.Events5;
using Auth.Mappers208;
using Auth.Models23;
using Billing.Contracts;
using Common.Contracts279;
using DataAccess.Shared;
using Documents.Processors;
using Export.Web130;
using Export.Web479;
using Imaging.Events;
using Notifications.Handlers112;
using Portal.Handlers;
using Scheduling.Mappers48;
using Scheduling.Processors397;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Api;
using Utilities.Validators;

namespace Utilities.Tests
{
    public struct Utilities_Tests_Result8
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class TestsContext : DbContext
    {
    }

}