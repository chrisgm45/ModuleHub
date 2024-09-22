#region     USINGS

using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using ModuleHub.Contracts;
using ModuleHub.Contracts.Interfaces;
using ModuleHub.DataAccess.Repositories.Common;
using ModuleHub.Protos;
using ModuleHub.Protos.CommunicationClient;
using ModuleHub.Protos.DataSource;


#endregion


namespace ModuleHub.GrpcService.Services

{

    public class CommunicationClientService : CommunicationClient.CommunicationClientBase

    {

        public override Task<CommunicationClientDTO> CreateCommunicationClient(CreateCommunicationClientRequest request, ServerCallContext context)
        {
            return base.CreateCommunicationClient(request, context);
        }

        public override Task<NullableCommunicationClientDTO> GetCommunicationClient(GetRequest request, ServerCallContext context)
        {
            return base.GetCommunicationClient(request, context);
        }




        public override Task<CommunicationClients> GetAllCommunicationClients(Empty request, ServerCallContext context)
        {
            return base.GetAllCommunicationClients(request, context);
        }

        public override Task<Empty> UpdateCommunicationClient(CommunicationClientDTO request, ServerCallContext context)
        {
            return base.UpdateCommunicationClient(request, context);
        }



        public override Task<Empty> DeleteCommunicationClient(DeleteRequest request, ServerCallContext context)
        {
            return base.DeleteCommunicationClient(request, context);
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
