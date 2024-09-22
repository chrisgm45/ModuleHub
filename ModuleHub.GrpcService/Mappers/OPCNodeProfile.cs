using AutoMapper;


namespace ModuleHub.GrpcService.Mappers
{
    public class OPCNodeProfile : Profile
    {
        public OPCNodeProfile()
        {

            CreateMap<ModuleHub.Domain.Entities.OPCNode,
                ModuleHub.Protos.OPCNode.OPCNodeDTO>()
                .ForMember(t => t.Id, o => o.MapFrom(s => s.Id.ToString()))
                .ForMember(t => t.AddressLabel, o => o.MapFrom(s => s.AddressLabel))
                .ForMember(t => t.CommunicationClient, o => o.MapFrom(s => s.CommunicationClient));


            CreateMap<ModuleHub.Protos.OPCNode.OPCNodeDTO,
                ModuleHub.Domain.Entities.OPCNode>()
                .ForMember(t => t.Id, o => o.MapFrom(s => new Guid(s.Id)))
                .ForMember(t => t.AddressLabel, o => o.MapFrom(s => s.AddressLabel))
                .ForMember(t => t.CommunicationClient, o => o.MapFrom(s => s.CommunicationClient));
        }
    }
}