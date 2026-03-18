using Admin.Service247;
using Auth.Data;
using Auth.Events78;
using Auth.Models236;
using Auth.Service;
using Common.Api57;
using Documents.Core;
using Documents.Processors;
using Documents.Service471;
using GalaxyWorks.Handlers;
using GalaxyWorks.Mappers318;
using Integration.Client;
using Integration.Tests45;
using Logging.Validators;
using Notifications.Service;
using Reporting.Client;
using Security.Validators428;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Api387;

namespace Integration.Processors
{
    public struct Integration_Processors_Point3
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}