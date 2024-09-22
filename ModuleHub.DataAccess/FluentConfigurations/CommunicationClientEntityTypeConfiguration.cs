#region     USINGS

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModuleHub.DataAccess.FluentConfigurations.Common;
using ModuleHub.Domain.Entities;

#endregion

namespace ModuleHub.DataAccess.FluentConfigurations
{

    /// <summary>
    /// Modela la Configuracion de la Tabla en BD de <see cref="CommunicationClient"/>
    /// </summary>
    public class CommunicationClientEntityTypeConfiguration : EntityTypeConfigurationBase<CommunicationClient>

    {
        /// <summary>
        /// Permite usar funciones para configurar la tabla 
        /// </summary>
        public virtual void Configure(EntityTypeBuilder<CommunicationClient> builder)
        {
            /// <summary>
            /// Define el nombre empleado en la Tabla de Base de Datos
            /// </summary>
            builder.ToTable("CommunicationClients");
            base.Configure(builder);
        }

    }
}
