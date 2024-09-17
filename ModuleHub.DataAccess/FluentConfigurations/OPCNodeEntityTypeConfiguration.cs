#region   USINGS

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModuleHub.Domain.Entities.Common;
using ModuleHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace ModuleHub.DataAccess.FluentConfigurations.Common
{

    /// <summary>
    /// Modela un OPC Node como clase derivada
    /// </summary>
    public class OPCNodeEntityTypeConfiguration : IEntityTypeConfiguration<OPCNode>
    {

        /// <summary>
        /// Permite usar funciones para configurar la tabla
        /// </summary>
        public void Configure(EntityTypeBuilder<OPCNode> builder)
        {

            /// <summary>
            /// Define el nombre empleado en la Tabla de Base de Datos
            /// </summary>
            builder.ToTable("OPCNodes");

            /// <summary>
            /// Indica que <see cref="OPCNode"/> hereda de <see cref="CommunicationNode"/>
            /// </summary>
            builder.HasBaseType(typeof(CommunicationNode));

        }


    }
}
