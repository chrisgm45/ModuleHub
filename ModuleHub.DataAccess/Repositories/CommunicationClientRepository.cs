#region   USINGS

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModuleHub.Contracts.Interfaces;
using ModuleHub.DataAccess.Contexts;
using ModuleHub.DataAccess.Repositories.Common;
using ModuleHub.Domain.Entities;

#endregion


namespace ModuleHub.DataAccess.Repositories.Common
{

    /// <summary>
    /// CRUDs para el Repositorio de la Entidad <see cref="CommunicationClient"/> 
    /// </summary>
    public class CommunicationClientRepository : RepositoryBase, ICommunicationClientRepository
    {


        /// <summary>
        /// Constructor del Contexto para el Repositorio Base
        /// </summary>
        /// <param name="applicationContext">Contexto de la Base de Datos</param>
        public CommunicationClientRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }



        /// <summary>
        /// Añade un <see cref="CommunicationClient"/>
        /// </summary>
        /// <param name="communicationClient"> Cliente de Comunicacion</param>
        public void AddCommunicationClient(CommunicationClient communicationClient)
        {
            _applicationContext.CommunicationClients.Add(communicationClient);
        }



        /// <summary>
        /// Elimina un <see cref="CommunicationClient"/>
        /// </summary>
        /// <param name="communicationClient">Cliente de Comunicacion</param>
        public void DeleteCommunicationClient(CommunicationClient communicationClient)
        {
            _applicationContext.CommunicationClients.Remove(communicationClient);
        }



        /// <summary>
        /// Obtiene todos los <see cref="CommunicationClient"/> de la Base de Datos
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CommunicationClient> GetAllCommunicationClients()
        {
            return _applicationContext.CommunicationClients.ToList();
        }




        /// <summary>
        /// Obtiene un <see cref="CommunicationClient"/> por su Identificador
        /// </summary>
        /// <param name="id"> Identificador del <see cref="CommunicationClient"/></param>
        /// <returns></returns>
        public CommunicationClient? GetCommunicationClientById(Guid id)
        {
            return _applicationContext.CommunicationClients.FirstOrDefault(x => x.Id == id);
        }


        /// <summary>
        /// Actualiza un <see cref="CommunicationClient"/>
        /// </summary>
        /// <param name="communicationClient"> Nodo de Comunicacion </param>
        public void UpdateCommunicationClient(CommunicationClient communicationClient)
        {
            _applicationContext.CommunicationClients.Update(communicationClient);
        }




    }
}