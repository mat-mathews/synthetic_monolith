using Admin.Client346;
using Admin.Events235;
using Admin.Processors35;
using Auth.Core;
using Auth.Core140;
using Auth.Events78;
using Auth.Web70;
using Billing.Core;
using Common.Events;
using DataAccess.Processors;
using Documents.Core;
using Documents.Shared452;
using Import.Data100;
using Import.Service291;
using Integration.Tests45;
using Portal.Mappers233;
using Reporting.Mappers239;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Import.Events493
{
    public interface IImport_Events493_Handler1
    {
        /// <summary>Processes the Import_Events493_Handler1 operation.</summary>
        void ProcessImport_Events493_Handler1();

        /// <summary>Validates the Import_Events493_Handler1 state.</summary>
        bool ValidateImport_Events493_Handler1();
    }

}