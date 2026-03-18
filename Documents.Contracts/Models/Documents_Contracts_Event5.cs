using Admin.Service247;
using Admin.Service339;
using Admin.Tests;
using Auth.Processors411;
using Auth.Service;
using DataAccess.Api454;
using Documents.Client;
using Documents.Data419;
using Documents.Service471;
using Imaging.Contracts473;
using Import.Contracts296;
using Logging.Tests;
using Notifications.Service;
using Security.Client137;
using Security.Models284;
using Security.Validators428;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Documents.Contracts
{
    /// <summary>Immutable data transfer record for Documents_Contracts_Event5.</summary>
    internal record Documents_Contracts_Event5(string Value, int Count, DateTime Timestamp);

}