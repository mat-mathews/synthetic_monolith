using Admin.Tests10;
using Auth.Client249;
using Auth.Contracts395;
using Auth.Processors;
using Auth.Processors400;
using Common.Core;
using DataAccess.Handlers482;
using Import.Data;
using Import.Service429;
using Integration.Processors321;
using Integration.Tests;
using Logging.Contracts373;
using Logging.Models436;
using Notifications.Models277;
using Notifications.Shared396;
using Portal.Processors52;
using Portal.Service;
using Scheduling.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Documents.Validators
{
    public struct Documents_Validators_Info5
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}