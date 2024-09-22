#region   USINGS

using ModuleHub.Contracts.Interfaces;
using ModuleHub.DataAccess.Contexts;
using ModuleHub.Domain.Entities.Common;

#endregion


namespace ModuleHub.DataAccess.Repositories.Common
{

    /// <summary>
    /// CRUDs para el Repositorio de la Entidad <see cref="CommunicationNode"/> 
    /// </summary>
    public class CommunicationNodeRepository : RepositoryBase, ICommunicationNodeRepository
    {


        /// <summary>
        /// Constructor del Contexto para el Repositorio Base
        /// </summary>
        /// <param name="applicationContext">Contexto de la Base de Datos</param>
        public CommunicationNodeRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }


        /// <summary>
        /// Añade un <see cref="CommunicationNode"/>
        /// </summary>
        /// <param name="communicationNode"> Nodo de Comunicacion</param>
        public void AddCommunicationNode(CommunicationNode communicationNode)
        {
            _applicationContext.CommunicationNodes.Add(communicationNode);
        }


        /// <summary>
        /// Elimina un <see cref="CommunicationNode"/>
        /// </summary>
        /// <param name="communicationNode">Nodo de Comunicacion</param>
        public void DeleteCommunicationNode(CommunicationNode communicationNode)
        {
            _applicationContext.CommunicationNodes.Remove(communicationNode);
        }




        /// <summary>
        /// Obtiene todos los <see cref="CommunicationNode"/> de la Base de Datos
        /// </summary>
        /// <typeparam name="T"> Tipo de <see cref="CommunicationNode"/></typeparam>
        /// <returns></returns>
        public IEnumerable<T> GetAllCommunicationNodes<T>() where T : CommunicationNode
        {
            return _applicationContext.Set<T>().ToList();
        }


        /// <summary>
        /// Obtiene un <see cref="CommunicationNode"/> por su Identificador
        /// </summary>
        /// <typeparam name="T">Tipo de <see cref="CommunicationNode"/></typeparam>
        /// <param name="id">Identificador del tipo de <see cref="CommunicationNode"/></param>
        /// <returns></returns>
        public T? GetCommunicationNodeById<T>(Guid id) where T : CommunicationNode
        {
            return _applicationContext.Set<T>().FirstOrDefault(x => x.Id == id);
        }


        /// <summary>
        /// Actualiza un <see cref="CommunicationNode"/>
        /// </summary>
        /// <param name="communicationNode"> Nodo de Comunicacion </param>
        public void UpdateCommunicationNode(CommunicationNode communicationNode)
        {
            _applicationContext.CommunicationNodes.Update(communicationNode);
        }




    }
}