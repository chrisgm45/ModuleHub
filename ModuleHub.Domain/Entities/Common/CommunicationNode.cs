#region    USINGS

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModuleHub.Domain.Entities;

#endregion


namespace ModuleHub.Domain.Entities.Common
{

    /// <summary>
    /// Modela un Nodo de Comunicacion
    /// </summary>
    public  class CommunicationNode : Entity
    {

        #region    PROPERTIES


        /// <summary>
        /// Cliente de Comunicacion al que pertenece el <see cref="CommunicationNode"/>
        /// </summary>
        [NotMapped]
        public CommunicationClient CommunicationClient { get; set; }


        /// <summary>
        /// Identificador del Cliente de Comunicacion al que pertenece el <see cref="CommunicationNode"/>
        /// </summary>
        public Guid ComunnicationClientId { get; set; }

        #endregion


        #region   CONSTRUCTORS

        /// <summary>
        /// Constructor por Defecto para EntityFramework
        /// </summary>
        protected CommunicationNode() { }



        /// </summary>
        /// <param name="id">CLiente de Comunicacion al que pertenece el <see cref="CommunicationNode"/></param>
        /// <param name="communicationClient">Identificador del CLiente de Comunicacion al que pertenece el <see cref="CommunicationNode"/</param>
        public CommunicationNode (Guid id, CommunicationClient communicationClient) : base(id)
        {
            CommunicationClient = communicationClient;
            ComunnicationClientId = communicationClient.id;    
        }


        #endregion

    }
}
