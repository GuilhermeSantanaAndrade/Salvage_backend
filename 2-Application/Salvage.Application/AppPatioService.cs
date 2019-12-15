using Salvage.Application.Interfaces;
using Salvage.Domain.Entities;
using Salvage.Domain.Interfaces.Services;

namespace Salvage.Application
{
    public class AppPatioService : AppBaseService<Patio>, IAppPatioService
    {
        private readonly IPatioService _service;
        public AppPatioService(IPatioService service)
            :base(service)
        {
            _service = service;
        }
    }
}
