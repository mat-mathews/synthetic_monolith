using Admin.Service247;
using Auth.Contracts402;
using Auth.Handlers281;
using Billing.Service;
using Common.Processors142;
using DataAccess.Service;
using Documents.Data492;
using Export.Contracts;
using Export.Validators;
using Export.Web;
using GalaxyWorks.Mappers318;
using Imaging.Contracts473;
using Imaging.Core204;
using Imaging.Web172;
using Logging.Handlers455;
using Logging.Mappers;
using Security.Contracts238;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Utilities.Contracts228
{
    public struct Utilities_Contracts228_Key1
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class Contracts228Context : DbContext
    {
    }

}