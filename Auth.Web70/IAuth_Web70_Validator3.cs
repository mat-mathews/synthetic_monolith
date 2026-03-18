using Admin.Events306;
using Admin.Validators240;
using Auth.Api143;
using Auth.Handlers;
using Auth.Mappers28;
using Auth.Processors400;
using BatchJobs.Validators;
using Common.Core118;
using DataAccess.Api341;
using Documents.Api251;
using Documents.Validators102;
using GalaxyWorks.Data453;
using Logging.Events289;
using Logging.Handlers285;
using Notifications.Models;
using Portal.Web158;
using Reporting.Handlers347;
using Security.Validators428;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Web70
{
    public interface IAuth_Web70_Validator3
    {
        /// <summary>Processes the Auth_Web70_Validator3 operation.</summary>
        void ProcessAuth_Web70_Validator3();

        /// <summary>Validates the Auth_Web70_Validator3 state.</summary>
        bool ValidateAuth_Web70_Validator3();
    }

}