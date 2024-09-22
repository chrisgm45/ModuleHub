#region     USINGS

using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using ModuleHub.Contracts;
using ModuleHub.Contracts.Interfaces;
using ModuleHub.DataAccess.Repositories.Common;
using ModuleHub.Protos;
using ModuleHub.Protos.DataSource;
using ModuleHub.Protos.CommunicationClient;
using MediatR;
using AutoMapper;
using ModuleHub.Application.CommunicationNodes.Commands.CreateModbusNode;
using ModuleHub.Protos.OPCNode;
using ModuleHub.Application.CommunicationClientsCQRS.Commands.CreateCommunicationClient;
using ModuleHub.Application.DataSources.Queries.GetDataSourceById;
using ModuleHub.Protos.ModbusNode;
using ModuleHub.Application.DataSources.Queries.GetAllDataSources;
using ModuleCentralizationIIoT.Application.MessageCQRS.Commands.UpdateMessage;
using ModuleHub.Application.DataSources.Commands.DeleteDataSource;


#endregion


namespace ModuleHub.GrpcService.Services

{

    public class CommunicationClientService : CommunicationClient.CommunicationClientBase

    {

        public override Task<CommunicationClientDTO> CreateCommunicationClient(CreateCommunicationClientRequest request, ServerCallContext context)
        {
            var command = new CreateCommunicationClientCommand(
               request.AddressIp,
               _mapper.Map<ModuleHub.Domain.Entities.DataSource>(request.DataSource));

            var result = _mediator.Send(command).Result;

            return Task.FromResult(_mapper.Map<CommunicationClientDTO>(result));
        }

        public override Task<NullableCommunicationClientDTO> GetCommunicationClient(GetRequest request, ServerCallContext context)
        {
            var query = new GetCommunicationClientByIdQuery(new Guid(request.Id));

            var result = _mediator.Send(query).Result;

            if (result is null)
                return Task.FromResult(new NullableCommunicationClientDTO() { Nule = NullValue.NullValue });
            return Task.FromResult(new NullableCommunicationClientDTO() { CommunicationClient = _mapper.Map<CommunicationClientDTO>(result) });
        }




        public override Task<CommunicationClients> GetAllCommunicationClients(Empty request, ServerCallContext context)
        {
            var query = new GetAllCommunicationClientsQuery();

            var result = _mediator.Send(query).Result;

            // Convirtiendo de lista de Nodos OPC al mensaje de lista de DTOs de Nodos OPC.
            var communicationClientsDTOs = new CommunicationClients();
            communicationClientsDTOs.Items.AddRange(result.Select(m => _mapper.Map<CommunicationClientDTO>(m)));

            return Task.FromResult(communicationClientsDTOs);
        }


        public override Task<Empty> UpdateCommunicationClient(CommunicationClientDTO request, ServerCallContext context)
        {
            var command = new UpdateCommunicationClientCommand(_mapper.Map<Domain.Entities.CommunicationClient>(request));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }



        public override Task<Empty> DeleteCommunicationClient(DeleteRequest request, ServerCallContext context)
        {
            var command = new DeleteCommunicationClientCommand(new Guid(request.Id));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }



        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CommunicationClientService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }



        private readonly ICommunicationClientRepository _communicationClientRepository;
        private readonly IUnitOfWork _unitOfWork;
        /// <summary>
        /// Inyeccion de instancias de los Servicios
        /// </summary>
        /// <param name="communicationClientRepository">Repositorio de la <see cref="CommunicationClient"/></param>
        /// <param name="unitOfWork">Unidad de Trabajo en Base de Datos</param>
        public CommunicationClientService(ICommunicationClientRepository communicationClientRepository, IUnitOfWork unitOfWork)
        {
            _communicationClientRepository = communicationClientRepository;
            _unitOfWork = unitOfWork;

        }

    }
}
