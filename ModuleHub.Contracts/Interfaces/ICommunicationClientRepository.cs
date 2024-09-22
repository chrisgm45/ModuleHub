#region   USINGS

using ModuleHub.Domain.Entities;

#endregion


namespace ModuleHub.Contracts.Interfaces
{

    /// <summary>
    /// CRUDs de Persistencia en Base de Datos del <see cref="CommunicationClient"/>
    /// </summary>
    public interface ICommunicationClientRepository
    {

        /// <summary>
        /// Añade un <see cref="CommunicationClient"/> a Base de Datos
        /// </summary>
        /// <param name="communicationClient"> Cliente de Comunicacion</param>
        void AddCommunicationClient(CommunicationClient communicationClient);



        /// <summary>
        /// Obtiene por su "ID" un <see cref="CommunicationClient"/> de Base de Datos
        /// </summary>
        /// <param name="id">Identificador del <see cref="CommunicationClient"/></param>
        /// <returns></returns>
        CommunicationClient? GetCommunicationClientById(Guid id);



        /// <summary>
        /// Obtiene todos los <see cref="CommunicationClient"/> de la Base de Datos
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CommunicationClient> GetAllCommunicationClients();



        /// <summary>
        /// Actualiza un <see cref="CommunicationClient"/> en Base de Datos
        /// </summary>
        /// <param name="communicationClient">Cliente de Comunicacion</param>
        void UpdateCommunicationClient(CommunicationClient communicationClient);



        /// <summary>
        /// Borra de la Base de Datos un <see cref="CommunicationClient"/>
        /// </summary>
        /// <param name="communicationClient">Cliente de Comunicacion</param>
        void DeleteCommunicationClient(CommunicationClient communicationClient);





    }
}
