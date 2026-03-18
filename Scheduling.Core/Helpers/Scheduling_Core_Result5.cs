using Admin.Core121;
using Admin.Processors;
using Auth.Mappers178;
using DataAccess.Contracts203;
using Documents.Data490;
using Documents.Models;
using Export.Handlers;
using Export.Processors111;
using GalaxyWorks.Models;
using Imaging.Shared115;
using Imaging.Validators;
using Import.Validators;
using Integration.Tests86;
using Notifications.Validators;
using Portal.Web158;
using Scheduling.Core273;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Validators;

namespace Scheduling.Core
{
    public struct Scheduling_Core_Result5
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}