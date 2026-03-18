using Admin.Events235;
using Auth.Client249;
using Auth.Mappers206;
using Auth.Processors319;
using Common.Client53;
using Documents.Shared427;
using Export.Tests;
using Export.Web;
using GalaxyWorks.Contracts94;
using Imaging.Contracts;
using Import.Events374;
using Import.Service;
using Import.Tests119;
using Integration.Api469;
using Integration.Client;
using Logging.Models;
using Logging.Shared315;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Api213
{
    internal interface ICommon_Api213_Repository1
    {
        /// <summary>Processes the Common_Api213_Repository1 operation.</summary>
        void ProcessCommon_Api213_Repository1();

        /// <summary>Validates the Common_Api213_Repository1 state.</summary>
        bool ValidateCommon_Api213_Repository1();
    }

}