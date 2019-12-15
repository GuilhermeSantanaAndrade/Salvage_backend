using Salvage.Application.Interfaces;
using Salvage.Domain.Entities;
using Salvage.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Salvage.Application
{
    public class AppDespachanteService : AppBaseService<Despachante>, IAppDespachanteService
    {
        private readonly IDespachanteService _service;
        public AppDespachanteService(IDespachanteService service)
            :base(service)
        {
            _service = service;
        }
    }
}
