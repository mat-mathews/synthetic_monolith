using Admin.Data408;
using Admin.Handlers447;
using Auth.Handlers467;
using Billing.Client;
using Common.Client269;
using Documents.Api;
using GalaxyWorks.Validators;
using Imaging.Handlers;
using Integration.Contracts290;
using Integration.Data;
using Integration.Processors;
using Notifications.Contracts;
using Notifications.Data446;
using Notifications.Mappers55;
using Portal.Service489;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Tests;
using Workflow.Handlers421;

namespace Billing.Models
{
    /// <summary>Defines the possible states for Billing_Models_Mode12.</summary>
    internal enum Billing_Models_Mode12
    {
        None = 0,
        Active = 1,
        Inactive = 2,
        Pending = 3,
        Processing = 4,
        Completed = 5,
        Failed = 6,
    }

}