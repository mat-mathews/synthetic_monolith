using Admin.Handlers61;
using Auth.Models23;
using Auth.Processors;
using DataAccess.Handlers482;
using Documents.Data492;
using GalaxyWorks.Api390;
using Import.Client7;
using Integration.Tests45;
using Logging.Core;
using Logging.Service382;
using Notifications.Events42;
using Portal.Contracts170;
using Portal.Data216;
using Portal.Events139;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Api387;
using Utilities.Service358;
using Utilities.Shared;
using Workflow.Core;

namespace Notifications.Processors20
{
    internal struct Notifications_Processors20_Key3
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}