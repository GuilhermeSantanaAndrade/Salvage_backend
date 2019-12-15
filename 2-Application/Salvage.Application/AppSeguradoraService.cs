using Salvage.Application.Interfaces;
using Salvage.Domain.Entities;
using Salvage.Domain.Interfaces.Services;
using System;
using System.Collections.Generic; 

namespace Salvage.Application
{
    public class AppSeguradoraService : AppBaseService<Seguradora>, IAppSeguradoraService
    {
        private readonly ISeguradoraService _service;
        public AppSeguradoraService(ISeguradoraService service)
            : base(service)
        {
            _service = service;
        } 
    }
}
