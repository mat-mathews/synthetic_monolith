using Admin.Core121;
using Admin.Service339;
using Auth.Processors411;
using Billing.Processors;
using Common.Mappers190;
using Common.Service258;
using Documents.Client58;
using Documents.Processors;
using GalaxyWorks.Shared437;
using Imaging.Data;
using Import.Models;
using Integration.Service;
using Integration.Shared;
using Notifications.Mappers;
using Security.Contracts;
using Security.Processors295;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Shared
{
    internal struct DataAccess_Shared_Info1
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}