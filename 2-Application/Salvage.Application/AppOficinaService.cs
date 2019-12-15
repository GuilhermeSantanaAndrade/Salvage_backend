using Salvage.Application.Interfaces;
using Salvage.Domain.Entities;
using Salvage.Domain.Interfaces.Services;

namespace Salvage.Application
{
    public class AppOficinaService:AppBaseService<Oficina>, IAppOficinaService
    {
        private readonly IOficinaService _service;
        public AppOficinaService(IOficinaService service)
            :base(service)
        {
            _service = service;
        }
    }
}
