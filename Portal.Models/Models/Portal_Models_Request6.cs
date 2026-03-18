using Admin.Client;
using Admin.Contracts;
using Admin.Service247;
using Auth.Client249;
using Auth.Handlers209;
using Auth.Mappers206;
using Auth.Models;
using Billing.Events;
using Common.Web488;
using DataAccess.Api294;
using GalaxyWorks.Shared;
using Imaging.Contracts;
using Imaging.Contracts473;
using Imaging.Handlers;
using Integration.Data;
using Notifications.Api;
using Security.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Models
{
    /// <summary>Immutable data transfer record for Portal_Models_Request6.</summary>
    public record Portal_Models_Request6(string Value, int Count, DateTime Timestamp);

    public class ModelsContext : DbContext
    {
    }

}