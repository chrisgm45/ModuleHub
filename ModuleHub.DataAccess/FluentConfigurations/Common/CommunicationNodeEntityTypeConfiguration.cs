#region     USINGS

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModuleHub.DataAccess.FluentConfigurations.Common;
using ModuleHub.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace ModuleHub.DataAccess.FluentConfigurations
{

    /// <summary>
    /// Modela la Configuracion de la Tabla en BD de <see cref="CommunicationNode"/>
    /// </summary>
    public class CommunicationNodeEntityTypeConfiguration : EntityTypeConfigurationBase<CommunicationNode>

    {
        /// <summary>
        /// Permite usar funciones para configurar la tabla 
        /// </summary>
        public virtual void Configure(EntityTypeBuilder<CommunicationNode> builder)
        {
            /// <summary>
            /// Define el nombre empleado en la Tabla de Base de Datos
            /// </summary>
            builder.ToTable("CommunicationNodes");
            base.Configure(builder);

            builder.HasOne(x => x.CommunicationClient).WithMany(x => x.CommunicationNodes).HasForeignKey(x => x.CommunicationClientId);

        }

    }
}