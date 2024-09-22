#region     USINGS

using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using ModuleHub.Contracts.Interfaces;
using ModuleHub.Contracts;
using ModuleHub.Protos;
using ModuleHub.Protos.CommunicationClient;
using ModuleHub.Protos.OPCNode;
using MediatR;
using ModuleHub.Application.CommunicationNodes.Commands.CreateModbusNode;
using AutoMapper;
using ModuleHub.Application.DataSources.Queries.GetDataSourceById;
using ModuleHub.Application.CommunicationNodes.Queries.GetAllOPCNodes;
using ModuleCentralizationIIoT.Application.MessageCQRS.Commands.UpdateMessage;
using ModuleHub.Application.DataSources.Commands.DeleteDataSource;


#endregion


namespace ModuleHub.GrpcService.Services

{

    public class OPCNodeService : OPCNode.OPCNodeBase

    {

        

        public override Task<OPCNodeDTO> CreateOPCNode(CreateOPCNodeRequest request, ServerCallContext context)
        {
            var command = new CreateOPCNodeCommand(
                request.AddressLabel,
                _mapper.Map<ModuleHub.Domain.Entities.CommunicationClient>(request.CommunicationClient));

            var result = _mediator.Send(command).Result;
           
            return Task.FromResult(_mapper.Map<OPCNodeDTO>(result));
        }

        public override Task<NullableOPCNodeDTO> GetOPCNode(GetRequest request, ServerCallContext context)
        {
            var query = new GetOPCNodeByIdQuery(new Guid(request.Id));

            var result = _mediator.Send(query).Result;

            if (result is null)
                return Task.FromResult(new NullableOPCNodeDTO() { Nule = NullValue.NullValue });
            return Task.FromResult(new NullableOPCNodeDTO() { OpcNode = _mapper.Map<OPCNodeDTO>(result) });
        }




        public override Task<OPCNodes> GetAllOPCNodes(Empty request, ServerCallContext context)
        {
            var query = new GetAllOPCNodesQuery();

            var result = _mediator.Send(query).Result;

            // Convirtiendo de lista de Nodos OPC al mensaje de lista de DTOs de Nodos OPC.
            var opcNodesDTOs = new OPCNodes();
            opcNodesDTOs.Items.AddRange(result.Select(m => _mapper.Map<OPCNodeDTO>(m)));

            return Task.FromResult(opcNodesDTOs);
        }

        public override Task<Empty> UpdateOPCNode(OPCNodeDTO request, ServerCallContext context)
        {
            var command = new UpdateOPCNodeCommand(_mapper.Map<Domain.Entities.OPCNode>(request));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }



        public override Task<Empty> DeleteOPCNode(DeleteRequest request, ServerCallContext context)
        {
            var command = new DeleteOPCNodeCommand(new Guid(request.Id));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }



        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public OPCNodeService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }





        private readonly ICommunicationNodeRepository _communicationNodeRepository;
        private readonly IUnitOfWork _unitOfWork;
        /// <summary>
        /// Inyeccion de instancias de los Servicios
        /// </summary>
        /// <param name="communicationNodeRepository">Repositorio del <see cref="ICommunicationClientRepository"/></param>
        /// <param name="unitOfWork">Unidad de Trabajo en Base de Datos</param>
        public OPCNodeService(ICommunicationNodeRepository communicationNodeRepository, IUnitOfWork unitOfWork)
        {
            _communicationNodeRepository = communicationNodeRepository;
            _unitOfWork = unitOfWork;




        }




    }
}
