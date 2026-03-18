using Admin.Data;
using Admin.Events235;
using Admin.Mappers324;
using Admin.Validators431;
using Auth.Api143;
using Auth.Processors;
using BatchJobs.Contracts;
using Documents.Validators;
using Imaging.Events303;
using Imaging.Web;
using Import.Api179;
using Import.Processors472;
using Import.Web;
using Integration.Client;
using Scheduling.Processors80;
using Security.Client349;
using Security.Models284;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Processors245
{
    internal interface ICommon_Processors245_Validator4
    {
        /// <summary>Processes the Common_Processors245_Validator4 operation.</summary>
        void ProcessCommon_Processors245_Validator4();

        /// <summary>Validates the Common_Processors245_Validator4 state.</summary>
        bool ValidateCommon_Processors245_Validator4();
    }

}