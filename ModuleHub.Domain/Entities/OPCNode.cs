#region   USINGS

using ModuleHub.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace ModuleHub.Domain.Entities
{

    /// <summary>
    /// Modela un Nodo Tipo OPC como Nodo de Comunicacion
    /// </summary>
    public class OPCNode : CommunicationNode
    {

        #region     PROPERTIES

        /// <summary>
        /// Direccion en el servidor que van a consumir 
        /// </summary>
        public string AddressLabel { get; set; }


        #endregion


        #region    CONSTRUCTORS


        /// <summary>
        /// Requerido por EntityFramework
        /// </summary>
        protected OPCNode() { }



        /// <summary>
        /// Inicializa un <see cref="OPCNode"/>
        /// </summary>
        /// <param name="addressLabel"> Direccion en el servidor que va a consumir el <see cref="OPCNode"/></param>
        public OPCNode(string addressLabel)
        {

            AddressLabel = addressLabel;

        }



        #endregion



    }
}
