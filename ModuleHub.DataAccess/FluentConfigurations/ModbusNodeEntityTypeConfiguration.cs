﻿#region   USINGS

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModuleHub.Domain.Entities;
using ModuleHub.Domain.Entities.Common;

#endregion

namespace ModuleHub.DataAccess.FluentConfigurations.Common
{

    /// <summary>
    /// Modela un MODBUS como clase derivada
    /// </summary>
    public class ModbusNodeEntityTypeConfiguration : IEntityTypeConfiguration<ModbusNode>
    {

        /// <summary>
        /// Permite usar funciones para configurar la tabla
        /// </summary>
        public void Configure(EntityTypeBuilder<ModbusNode> builder)
        {

            /// <summary>
            /// Define el nombre empleado en la Tabla de Base de Datos
            /// </summary>
            builder.ToTable("ModbusNodes");

            /// <summary>
            /// Indica que <see cref="ModbusNode"/> hereda de <see cref="CommunicationNode"/>
            /// </summary>
            builder.HasBaseType(typeof(CommunicationNode));
        }


    }
}