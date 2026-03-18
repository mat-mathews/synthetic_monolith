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
    internal interface IImaging_Events303_Repository10
    {
        /// <summary>Processes the Imaging_Events303_Repository10 operation.</summary>
        void ProcessImaging_Events303_Repository10();

        /// <summary>Validates the Imaging_Events303_Repository10 state.</summary>
        bool ValidateImaging_Events303_Repository10();
    }

    public class Events303Context : DbContext
    {
    }

}