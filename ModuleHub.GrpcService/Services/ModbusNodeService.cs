#region     USINGS

using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using ModuleHub.Contracts.Interfaces;
using ModuleHub.Contracts;
using ModuleHub.Protos;
using ModuleHub.Protos.CommunicationClient;
using ModuleHub.Protos.ModbusNode;
using ModuleHub.DataAccess.Repositories.Common;
using MediatR;
using AutoMapper;
using ModuleHub.Application.CommunicationNodes.Commands.CreateModbusNode;
using ModuleHub.Protos.OPCNode;
using ModuleHub.Application.DataSources.Queries.GetDataSourceById;
using ModuleHub.Application.CommunicationNodes.Queries.GetAllOPCNodes;
using ModuleHub.Application.CommunicationNodes.Queries.GetAllModbusNodes;
using ModuleCentralizationIIoT.Application.MessageCQRS.Commands.UpdateMessage;
using ModuleHub.Application.DataSources.Commands.DeleteDataSource;


#endregion


namespace ModuleHub.GrpcService.Services

{

    public class ModbusNodeService : ModbusNode.ModbusNodeBase

    {

        public override Task<ModbusNodeDTO> CreateModbusNode(CreateModbusNodeRequest request, ServerCallContext context)
        {
            var command = new CreateModbusNodeCommand(
               request.Name,
               request.RecordSource,
               _mapper.Map<ModuleHub.Domain.Entities.CommunicationClient>(request.CommunicationClient));

            var result = _mediator.Send(command).Result;

            return Task.FromResult(_mapper.Map<ModbusNodeDTO>(result));
        }

        public override Task<NullableModbusNodeDTO> GetModbusNode(GetRequest request, ServerCallContext context)
        {
            var query = new GetModbusNodeByIdQuery(new Guid(request.Id));

            var result = _mediator.Send(query).Result;

            if (result is null)
                return Task.FromResult(new NullableModbusNodeDTO() { Nule = NullValue.NullValue });
            return Task.FromResult(new NullableModbusNodeDTO() { ModbusNode = _mapper.Map<ModbusNodeDTO>(result) });
        }




        public override Task<ModbusNodes> GetAllModbusNodes(Empty request, ServerCallContext context)
        {
            var query = new GetAllModbusNodesQuery();

            var result = _mediator.Send(query).Result;

            // Convirtiendo de lista de Nodos MODBUS al mensaje de lista de DTOs de Nodos MODBUS.
            var modbusNodesDTOs = new ModbusNodes();
            modbusNodesDTOs.Items.AddRange(result.Select(m => _mapper.Map<ModbusNodeDTO>(m)));

            return Task.FromResult(modbusNodesDTOs);
        }

        public override Task<Empty> UpdateModbusNode(ModbusNodeDTO request, ServerCallContext context)
        {
            var command = new UpdateModbusNodeCommand(_mapper.Map<Domain.Entities.ModbusNode>(request));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }



        public override Task<Empty> DeleteModbusNode(DeleteRequest request, ServerCallContext context)
        {
            var command = new DeleteModbusNodeCommand(new Guid(request.Id));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }




        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ModbusNodeService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }



        private readonly ICommunicationNodeRepository _communicationNodeRepository;
        private readonly IUnitOfWork _unitOfWork;
        /// <summary>
        /// Inyeccion de instancias de los Servicios
        /// </summary>
        /// <param name="communicationNodeRepository">Repositorio del <see cref="ICommunicationNodeRepository"/></param>
        /// <param name="unitOfWork">Unidad de Trabajo en Base de Datos</param>
        public ModbusNodeService(ICommunicationNodeRepository communicationNodeRepository, IUnitOfWork unitOfWork)
        {
            _communicationNodeRepository = communicationNodeRepository;
            _unitOfWork = unitOfWork;




        }
    }
}