#region    USINGS

using ModuleHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace ModuleHub.Contracts.Interfaces
{

    /// <summary>
    /// CRUDs de Persistencia en Base de Datos del <see cref="OPCNode"/>
    /// </summary>
    public interface IOPCNodeRepository : ICommunicationNodeRepository
    {



        /// <summary>
        /// Añade un <see cref="OPCNode"/> a Base de Datos
        /// </summary>
        /// <param name="oPCNode"> Nodo OPC </param>
        void AddOPCNode(OPCNode oPCNode) ;



        /// <summary>
        /// Obtiene por su "ID" un <see cref="OPCNode"/> de Base de Datos
        /// </summary>
        /// <param name="id">Identificador del <see cref="OPCNode"/></param>
        /// <returns></returns>
        OPCNode? GetOPCNodeById(Guid id);



        /// <summary>
        /// Obtiene todos los <see cref="OPCNode"/> de la Base de Datos
        /// </summary>
        /// <returns></returns>
        public IEnumerable<OPCNode> GetAllOPCNodes();



        /// <summary>
        /// Actualiza un <see cref="OPCNode"/> en Base de Datos
        /// </summary>
        /// <param name="oPCNode">Nodo OPC</param>
        void UpdateOPCNode(OPCNode oPCNode );



        /// <summary>
        /// Borra de la Base de Datos un <see cref="OPCNode"/>
        /// </summary>
        /// <param name="oPCNode">Nodo OPC</param>
        void DeleteOPCNode(OPCNode oPCNode);

    }
}

