#region     USINGS

using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using ModuleHub.Contracts.Interfaces;
using ModuleHub.Contracts;
using ModuleHub.Protos;
using ModuleHub.Protos.CommunicationClient;
using ModuleHub.Protos.OPCNode;


#endregion


namespace ModuleHub.GrpcService.Services

{

    public class OPCNodeService : OPCNode.OPCNodeBase

    {

        public override Task<OPCNodeDTO> CreateOPCNode(CreateOPCNodeRequest request, ServerCallContext context)
        {
            return base.CreateOPCNode(request, context);
        }

        public override Task<NullableOPCNodeDTO> GetOPCNode(GetRequest request, ServerCallContext context)
        {
            return base.GetOPCNode(request, context);
        }




        public override Task<OPCNodes> GetAllOPCNodes(Empty request, ServerCallContext context)
        {
            return base.GetAllOPCNodes(request, context);
        }

        public override Task<Empty> UpdateOPCNode(OPCNodeDTO request, ServerCallContext context)
        {
            return base.UpdateOPCNode(request, context);
        }



        public override Task<Empty> DeleteOPCNode(DeleteRequest request, ServerCallContext context)
        {
            return base.DeleteOPCNode(request, context);
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
