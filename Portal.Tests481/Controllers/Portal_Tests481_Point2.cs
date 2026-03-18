using Admin.Handlers;
using Admin.Handlers61;
using Admin.Tests;
using Auth.Events5;
using Auth.Processors411;
using DataAccess.Client113;
using DataAccess.Processors;
using Export.Processors104;
using Import.Client64;
using Import.Contracts131;
using Import.Handlers354;
using Integration.Mappers242;
using Integration.Validators;
using Logging.Core159;
using Notifications.Client257;
using Security.Tests223;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Mappers232;
using Utilities.Processors;

namespace Portal.Tests481
{
    public struct Portal_Tests481_Point2
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}