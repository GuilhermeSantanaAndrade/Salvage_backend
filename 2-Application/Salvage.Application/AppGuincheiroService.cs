
using AutoMapper;
using Salvage.Application.Interfaces; 
using Salvage.Domain.Entities;
using Salvage.Domain.Interfaces.Services; 
using System;
using System.Collections.Generic;

namespace Salvage.Application
{
    public class AppGuincheiroService: AppBaseService<Guincheiro>, IAppGuincheiroService
    {
        private readonly IGuincheiroService _service;

        public AppGuincheiroService(IGuincheiroService service)
            :base(service)
        {
            _service = service;
        }

        public IEnumerable<Guincheiro> SelecionarPorProximidade()
        {
            return _service.SelecionarPorProximidade();
        }
    }
}
 