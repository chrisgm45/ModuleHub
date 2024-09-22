#region    USINGS

using ModuleHub.Domain.Entities.Common;

#endregion


namespace ModuleHub.Contracts.Interfaces
{

    /// <summary>
    /// CRUDs de Persistencia en Base de Datos del <see cref="CommunicationNode"/>
    /// </summary>
    public interface ICommunicationNodeRepository
    {

        /// <summary>
        /// Añade un <see cref="CommunicationNode"/> a Base de Datos
        /// </summary>
        /// <param name="communicationNode">Nodo de Comunicacion</param>
        void AddCommunicationNode(CommunicationNode communicationNode);


        /// <summary>
        /// Obtiene por su "ID" un <see cref="CommunicationNode"/> de Base de Datos
        /// </summary>
        /// <typeparam name="T">Tipo de <see cref="CommunicationNode"/></typeparam>
        /// <param name="id">Identificador del tipo de <see cref="CommunicationNode"/></param>
        /// <returns></returns>
        T? GetCommunicationNodeById<T>(Guid id) where T : CommunicationNode;



        /// <summary>
        /// Obtiene todos los <see cref="CommunicationNode"/> de la Base de Datos
        /// </summary>
        /// <typeparam name="T">Tipo de <see cref="CommunicationNode"/></typeparam>
        /// <returns></returns>
        IEnumerable<T> GetAllCommunicationNodes<T>() where T : CommunicationNode;



        /// <summary>
        /// Actualiza un <see cref="CommunicationNode"/> en Base de Datos
        /// </summary>
        /// <param name="communicationNode"> Nodo de Comunicacion</param>
        void UpdateCommunicationNode(CommunicationNode communicationNode);



        /// <summary>
        /// Borra de la Base de Datos un <see cref="CommunicationNode"/>
        /// </summary>
        /// <param name="communicationNode">Nodo de Comunicacion</param>
        void DeleteCommunicationNode(CommunicationNode communicationNode);




    }
}
