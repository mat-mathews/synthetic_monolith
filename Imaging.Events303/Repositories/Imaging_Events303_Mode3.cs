using Admin.Client346;
using Auth.Mappers;
using Auth.Tests498;
using Common.Handlers;
using Documents.Data492;
using Documents.Models;
using Export.Mappers237;
using GalaxyWorks.Handlers478;
using Imaging.Mappers93;
using Imaging.Models;
using Import.Data193;
using Import.Processors;
using Notifications.Mappers;
using Reporting.Data;
using Scheduling.Service211;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Service161;

namespace Imaging.Events303
{
    /// <summary>Defines the possible states for Imaging_Events303_Mode3.</summary>
    public enum Imaging_Events303_Mode3
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