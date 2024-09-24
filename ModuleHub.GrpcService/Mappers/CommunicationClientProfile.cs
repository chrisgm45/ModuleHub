
using AutoMapper;

namespace ModuleHub.GrpcService.Mappers
{
    public class CommunicationClientProfile : Profile
    {
        public CommunicationClientProfile()
        {
            CreateMap<ModuleHub.Domain.Entities.CommunicationClient,
                ModuleHub.Protos.CommunicationClient.CommunicationClientDTO>()
                .ForMember(t => t.Id, o => o.MapFrom(s => s.Id.ToString()))
                .ForMember(t => t.AddressIp, o => o.MapFrom(s => s.AddressIp))
                .ForMember(t => t.ConnectionPort, o => o.MapFrom(s => s.ConnectionPort))
                .ForMember(t => t.DataSource, o => o.MapFrom(s => s.DataSource))
           //   .ForMember(t => t.CommunicationClientType, o => o.MapFrom(s => (ModuleHub.Protos.CommunicationClientType)s.CommunicationClientType))

                 ;

            CreateMap<ModuleHub.Protos.CommunicationClient.CommunicationClientDTO,
                    ModuleHub.Domain.Entities.CommunicationClient>()
                    .ForMember(t => t.Id, o => o.MapFrom(s => new Guid(s.Id)))
                    .ForMember(t => t.AddressIp, o => o.MapFrom(s => s.AddressIp))
                    .ForMember(t => t.ConnectionPort, o => o.MapFrom(s => s.ConnectionPort))
                    .ForMember(t => t.DataSource, o => o.MapFrom(s => s.DataSource))
               //    .ForMember(t => t.CommunicationClientType, o => o.MapFrom(s => (ModuleHub.Domain.Utilities.Types.CommunicationClientType)s.CommunicationClientType))
                    ;
        }
    }
}
