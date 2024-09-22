#region      USINGS

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#endregion

namespace ModuleHub.Domain.Entities.Common
{

    /// <summary>
    /// Clase base para todas las entidades en el soporte de datos.
    /// </summary>
    public abstract class Entity
    {
        #region   PROPERTIES


        /// Define a "Id" como llave Primaria en Base Datos
        [Key]
        // El "Id" es generado por la Base de Datos
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        /// Define el Identificador para cada <see cref="Entity"/>
        /// </summary>
        public Guid Id { get; set; }

        #endregion


        #region     CONSTRUCTORS


        /// <summary>
        /// Constructor por Defecto para EntityFramework
        /// </summary>
        protected Entity() { }


        /// <summary>
        /// Inicializa una <see cref="Entity"/>
        /// </summary>
        /// <param name="id">Identificador en Base Datos</param>
        public Entity(Guid id)
        {
            Id = id;
        }

        #endregion
    }
}

