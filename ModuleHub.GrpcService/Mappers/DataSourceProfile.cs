
using AutoMapper;

namespace ModuleHub.GrpcService.Mappers
    {
        public class DataSourceProfile : Profile
        {
            public DataSourceProfile()
            {
                CreateMap<ModuleHub.Domain.Entities.DataSource,
                    ModuleHub.Protos.DataSource.DataSourceDTO>()
                    .ForMember(t => t.Id, o => o.MapFrom(s => s.Id.ToString()))
                    .ForMember(t => t.Code, o => o.MapFrom(s => s.Code))
                    .ForMember(t => t.InputsCounter, o => o.MapFrom(s => s.InputsCounter))
                    .ForMember(t => t.OutputsCounter, o => o.MapFrom(s => s.OutputsCounter))
                    .ForMember(t => t.Description, o => o.MapFrom(s => s.Description))
                    .ForMember(t => t.Location, o => o.MapFrom(s => s.Location))
                    .ForMember(t => t.DataSourceType, o => o.MapFrom( s => (ModuleHub.Protos.DataSourceType)s.DataSourceType))

                     ;

            CreateMap<ModuleHub.Protos.DataSource.DataSourceDTO,
                    ModuleHub.Domain.Entities.DataSource>()
                    .ForMember(t => t.Id, o => o.MapFrom(s => new Guid(s.Id)))
                    .ForMember(t => t.Code, o => o.MapFrom(s => s.Code))
                    .ForMember(t => t.InputsCounter, o => o.MapFrom(s => s.InputsCounter))
                    .ForMember(t => t.OutputsCounter, o => o.MapFrom(s => s.OutputsCounter))
                    .ForMember(t => t.Description, o => o.MapFrom(s => s.Description))
                    .ForMember(t => t.Location, o => o.MapFrom(s => s.Location))
                    .ForMember(t => t.DataSourceType, o => o.MapFrom(s => (ModuleHub.Domain.Utilities.Types.DataSourceType)s.DataSourceType))
                    ;
            }
        }
    }


