#region    USINGS

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModuleHub.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace ModuleHub.DataAccess.FluentConfigurations.Common
{

    /// <summary>
    /// Configurada para que hereden de ellas las clases derevidas
    /// </summary>
    public abstract class EntityTypeConfigurationBase<T>
        : IEntityTypeConfiguration<T>
       where T : Entity
    {

        /// <summary>
        /// Permite usar funciones para configurar la tabla 
        /// </summary>
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            /// <summary>
            /// Define el ID como un Requisito indispensable 
            /// </summary>
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();
        }

    }
}

