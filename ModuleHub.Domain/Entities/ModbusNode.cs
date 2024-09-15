#region   USINGS

using ModuleHub.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace ModuleHub.Domain.Entities
{

    /// <summary>
    /// Modela un Nodo Tipo MODBUS como Nodo de Comunicacion
    /// </summary>
    public class ModbusNode : CommunicationNode
    {
        #region    PROPERTIES


        /// <summary>
        /// Nombre del <see cref="ModbusNode"/>
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// Registro a partir del cual el <see cref="ModbusNode"/> va a obtener la info
        /// </summary>
        public int RecordSource { get; set; }


        /// <summary>
        /// Cantidad de Registros a leer por el <see cref="ModbusNode"/>
        /// </summary>
        public int RecordToRead { get; set; }



        #endregion


        #region     CONSTRUCTORS


        /// <summary>
        /// Requerido por EntityFramework
        /// </summary>
        protected ModbusNode() { }



        /// <summary>
        /// Inicializa un <see cref="ModbusNode"/>
        /// </summary>
        /// <param name="name"> Nombre del <see cref="ModbusNode"/> </param>
        /// <param name="recordSource"> Registro del cual obtiene la info el <see cref="ModbusNode"/>/></param>
        /// <param name="recordToRead"> Cantidad de Registros a leer por el <see cref="ModbusNode"/></param>
        public ModbusNode(string name, int recordSource, int recordToRead)
        {
            Name = name;
            RecordSource = recordSource;
            RecordToRead = recordToRead;

        }


        #endregion

    }
}
