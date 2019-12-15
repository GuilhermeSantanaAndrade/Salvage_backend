using AutoMapper;  

namespace Salvage.Infra.Data.Repositories.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DomainToDTOMappingProfile>();
                x.AddProfile<DTOToDomainMappingProfile>();
            });
        } 
    } 
}
