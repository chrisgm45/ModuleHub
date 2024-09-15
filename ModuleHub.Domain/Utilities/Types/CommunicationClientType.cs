#region    USINGS

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace ModuleHub.Domain.Utilities.Types
{
    /// <summary>
    /// Tipo de Cliente de Comunicacion
    /// </summary>
    public enum CommunicationClientType
    {
        /// <summary>
        /// Open Protocol Communication MODBUS ( HARDWARE to HARDWARE )
        /// </summary>
        MODBUS,

        /// <summary>
        /// Open Protocol Communication  ( SOFTWARE to SOFTWARE )
        /// </summary>
        OPC,

    }
}
