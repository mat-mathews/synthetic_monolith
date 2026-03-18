using Admin.Api;
using Admin.Client177;
using Admin.Handlers61;
using Admin.Models;
using Admin.Validators431;
using Auth.Events78;
using DataAccess.Contracts404;
using DataAccess.Models;
using Documents.Data492;
using Export.Handlers;
using Imaging.Mappers275;
using Import.Contracts180;
using Notifications.Handlers470;
using Portal.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Contracts;
using Workflow.Api148;
using Workflow.Models;

namespace Import.Client7
{
    internal interface IImport_Client7_Factory4
    {
        /// <summary>Processes the Import_Client7_Factory4 operation.</summary>
        void ProcessImport_Client7_Factory4();

        /// <summary>Validates the Import_Client7_Factory4 state.</summary>
        bool ValidateImport_Client7_Factory4();
    }

}