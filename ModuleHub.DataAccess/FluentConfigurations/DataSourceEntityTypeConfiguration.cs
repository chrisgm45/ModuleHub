#region     USINGS

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModuleHub.DataAccess.FluentConfigurations.Common;
using ModuleHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace ModuleHub.DataAccess.FluentConfigurations
{

    /// <summary>
    /// Modela la Configuracion de la Tabla en BD de <see cref="DataSource"/>
    /// </summary>
    public class DataSourceEntityTypeConfiguration : EntityTypeConfigurationBase<DataSource>

    {
        /// <summary>
        /// Permite usar funciones para configurar la tabla 
        /// </summary>
        public virtual void Configure(EntityTypeBuilder<DataSource> builder)
        {
            /// <summary>
            /// Define el nombre empleado en la Tabla de Base de Datos
            /// </summary>
            builder.ToTable("DataSources");
            base.Configure(builder);


        }

    }
}
