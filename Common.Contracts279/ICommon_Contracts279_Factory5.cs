using Admin.Data117;
using Admin.Events235;
using Admin.Handlers;
using Admin.Processors;
using Billing.Mappers124;
using Common.Core118;
using Common.Events367;
using Documents.Shared487;
using Export.Api12;
using Imaging.Api;
using Import.Events;
using Import.Service291;
using Integration.Handlers17;
using Integration.Handlers333;
using Portal.Validators227;
using Reporting.Events220;
using Scheduling.Models260;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Data;

namespace Common.Contracts279
{
    public interface ICommon_Contracts279_Factory5
    {
        /// <summary>Processes the Common_Contracts279_Factory5 operation.</summary>
        void ProcessCommon_Contracts279_Factory5();

        /// <summary>Validates the Common_Contracts279_Factory5 state.</summary>
        bool ValidateCommon_Contracts279_Factory5();
    }

}