using Admin.Validators431;
using Auth.Mappers208;
using Auth.Processors319;
using DataAccess.Shared;
using Documents.Data492;
using Documents.Shared427;
using Export.Core386;
using Export.Mappers237;
using Export.Processors111;
using Export.Shared;
using GalaxyWorks.Data224;
using GalaxyWorks.Service;
using Import.Api272;
using Import.Handlers354;
using Integration.Client;
using Scheduling.Web19;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Client351;
using Workflow.Data340;

namespace Export.Contracts
{
    internal struct Export_Contracts_Range2
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}