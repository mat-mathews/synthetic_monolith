using Admin.Data117;
using Admin.Models;
using Admin.Processors35;
using Auth.Mappers178;
using Billing.Client182;
using Common.Web488;
using DataAccess.Models;
using DataAccess.Validators254;
using Documents.Handlers;
using Import.Data100;
using Import.Service429;
using Integration.Data;
using Integration.Validators;
using Security.Client353;
using Security.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Processors91;

namespace Export.Mappers237
{
    public struct Export_Mappers237_Result
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}