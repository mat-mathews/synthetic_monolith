using Admin.Core121;
using Admin.Models;
using Admin.Shared363;
using Auth.Service;
using Billing.Contracts;
using Common.Handlers;
using Export.Data150;
using Export.Service;
using GalaxyWorks.Data224;
using GalaxyWorks.Handlers84;
using Imaging.Data;
using Notifications.Contracts;
using Notifications.Tests195;
using Portal.Shared;
using Scheduling.Api;
using Security.Shared155;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Documents.Data
{
    public struct Documents_Data_Result2
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}