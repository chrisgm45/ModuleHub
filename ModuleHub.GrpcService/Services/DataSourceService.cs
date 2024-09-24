#region     USINGS

using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using MediatR;
using ModuleCentralizationIIoT.Application.MessageCQRS.Commands.UpdateMessage;
using ModuleHub.Application.CommunicationNodes.Commands.CreateModbusNode;
using ModuleHub.Application.CommunicationNodes.Queries.GetAllOPCNodes;
using ModuleHub.Application.DataSources.Commands.DeleteDataSource;
using ModuleHub.Application.DataSources.Queries.GetAllDataSources;
using ModuleHub.Application.DataSources.Queries.GetDataSourceById;
using ModuleHub.Application.DataSourcesCQRS.Commands.CreateDataSource;
using ModuleHub.Contracts;
using ModuleHub.Contracts.Interfaces;
using ModuleHub.DataAccess.Repositories.Common;
using ModuleHub.Domain;
using ModuleHub.Protos;
using ModuleHub.Protos.DataSource;
using ModuleHub.Protos.OPCNode;


#endregion


namespace ModuleHub.GrpcService.Services

{

    public class DataSourceService : DataSource.DataSourceBase

    {

        //private readonly IRequestHandler
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IDataSourceRepository _dataSourceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DataSourceService(IMediator mediator, IMapper mapper, IDataSourceRepository dataSourceRepository, IUnitOfWork unitOfWork)
        {
            _mediator = mediator;
            _mapper = mapper;
            _dataSourceRepository = dataSourceRepository;
                _unitOfWork = unitOfWork;
        }


        public override Task<DataSourceDTO> CreateDataSource(CreateDataSourceRequest request, ServerCallContext context)
        {
            var command = new CreateDataSourceCommand(
                request.Code,
                request.InputsCounter,
                request.OutputsCounter);

            var result = _mediator.Send(command).Result;

            return Task.FromResult(_mapper.Map<DataSourceDTO>(result));
        }

        public override Task<NullableDataSourceDTO> GetDataSource(GetRequest request, ServerCallContext context)
        {
            var query = new GetDataSourceByIdQuery(new Guid(request.Id));

            var result = _mediator.Send(query).Result;

            if (result is null)
                return Task.FromResult(new NullableDataSourceDTO() { Nule = NullValue.NullValue });
            return Task.FromResult(new NullableDataSourceDTO() { DataSource = _mapper.Map<DataSourceDTO>(result) });
        }

        public override Task<DataSources> GetAllDataSources(Empty request, ServerCallContext context)
        {
            var query = new GetAllDataSourcesQuery();

            var result = _mediator.Send(query).Result;

            // Convirtiendo de lista de Nodos OPC al mensaje de lista de DTOs de Nodos OPC.
            var dataSourcesDTOs = new DataSources();
            dataSourcesDTOs.Items.AddRange(result.Select(m => _mapper.Map<DataSourceDTO>(m)));

            return Task.FromResult(dataSourcesDTOs);
        }

        public override Task<Empty> UpdateDataSource(DataSourceDTO request, ServerCallContext context)
        {
            var command = new UpdateDataSourceCommand(_mapper.Map<Domain.Entities.DataSource>(request));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }



        public override Task<Empty> DeleteDataSource(DeleteRequest request, ServerCallContext context)
        {
            var command = new DeleteDataSourceCommand(new Guid(request.Id));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }



       
        ///// <summary>
        ///// Inyeccion de instancias de los Servicios
        ///// </summary>
        ///// <param name="dataSourceRepository">Repositorio de la <see cref="DataSource"/></param>
        ///// <param name="unitOfWork">Unidad de Trabajo en Base de Datos</param>
        ////

        //}



    }
}
