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
    public struct Import_Client7_Key3
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}