using AutoMapper;


namespace ModuleHub.GrpcService.Mappers
{
    public class ModbusNodeProfile : Profile
    {
        public ModbusNodeProfile()
        {

            CreateMap<ModuleHub.Domain.Entities.ModbusNode,
                ModuleHub.Protos.ModbusNode.ModbusNodeDTO>()
                .ForMember(t => t.Id, o => o.MapFrom(s => s.Id.ToString()))
                .ForMember(t => t.Name, o => o.MapFrom(s => s.Name))
                .ForMember(t => t.RecordSource, o => o.MapFrom(s => s.RecordSource))
                .ForMember(t => t.RecordToRead, o => o.MapFrom(s => s.RecordToRead))
                .ForMember(t => t.CommunicationClient, o => o.MapFrom(s => s.CommunicationClient));


            CreateMap<ModuleHub.Protos.ModbusNode.ModbusNodeDTO,
                ModuleHub.Domain.Entities.ModbusNode>()
                .ForMember(t => t.Id, o => o.MapFrom(s => new Guid(s.Id)))
                .ForMember(t => t.Name, o => o.MapFrom(s => s.Name))
                .ForMember(t => t.RecordSource, o => o.MapFrom(s => s.RecordSource))
                .ForMember(t => t.RecordToRead, o => o.MapFrom(s => s.RecordToRead))
                .ForMember(t => t.CommunicationClient, o => o.MapFrom(s => s.CommunicationClient));
        }
    }
}
                
