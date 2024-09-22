#region     USINGS

using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using ModuleHub.Contracts.Interfaces;
using ModuleHub.Contracts;
using ModuleHub.Protos;
using ModuleHub.Protos.CommunicationClient;
using ModuleHub.Protos.ModbusNode;
using ModuleHub.DataAccess.Repositories.Common;


#endregion


namespace ModuleHub.GrpcService.Services

{

    public class ModbusNodeService : ModbusNode.ModbusNodeBase

    {

        public override Task<ModbusNodeDTO> CreateModbusNode(CreateModbusNodeRequest request, ServerCallContext context)
        {
            return base.CreateModbusNode(request, context);
        }

        public override Task<NullableModbusNodeDTO> GetModbusNode(GetRequest request, ServerCallContext context)
        {
            return base.GetModbusNode(request, context);
        }




        public override Task<ModbusNodes> GetAllModbusNodes(Empty request, ServerCallContext context)
        {
            return base.GetAllModbusNodes(request, context);
        }

        public override Task<Empty> UpdateModbusNode(ModbusNodeDTO request, ServerCallContext context)
        {
            return base.UpdateModbusNode(request, context);
        }



        public override Task<Empty> DeleteModbusNode(DeleteRequest request, ServerCallContext context)
        {
            return base.DeleteModbusNode(request, context);
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