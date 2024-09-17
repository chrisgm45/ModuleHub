#region    USINGS

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModuleHub.Contracts.Interfaces;
using ModuleHub.Domain.Entities;

#endregion

namespace ModuleHub.Contracts.Interfaces
{

    /// <summary>
    /// CRUDs de Persistencia en Base de Datos del <see cref="ModbusNode"/>
    /// </summary>
    public interface IModbusNodeRepository : ICommunicationNodeRepository
    {



        /// <summary>
        /// Añade un <see cref="ModbusNode"/> a Base de Datos
        /// </summary>
        /// <param name="modbusNode"> Nodo MODBUS </param>
        void AddModbusNode(ModbusNode modbusNode);



        /// <summary>
        /// Obtiene por su "ID" un <see cref="ModbusNode"/> de Base de Datos
        /// </summary>
        /// <param name="id">Identificador del <see cref="ModbusNode"/></param>
        /// <returns></returns>
        ModbusNode? GetModbusNodeById(Guid id);



        /// <summary>
        /// Obtiene todos los <see cref="ModbusNode"/> de la Base de Datos
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ModbusNode> GetAllmodbusNodes();



        /// <summary>
        /// Actualiza un <see cref="ModbusNode"/> en Base de Datos
        /// </summary>
        /// <param name="modbusNode">Nodo MODBUS</param>
        void UpdateModbusNode(ModbusNode modbusNode);



        /// <summary>
        /// Borra de la Base de Datos un <see cref="ModbusNode"/>
        /// </summary>
        /// <param name="modbusNode">Nodo MODBUS</param>
        void DeleteModbusNode(ModbusNode modbusNode);

    }
}
