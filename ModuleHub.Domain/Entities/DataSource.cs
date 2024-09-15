#region  USINGS

using ModuleHub.Domain.Entities.Common;
using ModuleHub.Domain.Utilities.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace ModuleHub.Domain.Entities
{

    /// <summary>
    /// Modela una <see cref="DataSource"/> 
    /// </summary>
    public class DataSource : Entity
    {

        #region    PROPERTIES

        /// <summary>
        /// Codigo Alfanumerico de la <see cref="DataSource"/> 
        /// </summary>
        [Required]
        public string Code { get; set; }

        /// <summary>
        /// Cantidad de Entradas de la <see cref="DataSource"/> 
        /// </summary>
        [Required]
        public int InputsCounter { get; set; }

        /// <summary>
        /// Cantidad de Salidas de la <see cref="DataSource"/> 
        /// </summary>
        [Required]
        public int OutputsCounter { get; set; }


        /// <summary>
        /// Descripcion de la <see cref="DataSource"/> 
        /// </summary>
        public string Description { get; set; }


        /// <summary>
        /// Ubicacion en la Planta de la <see cref="DataSource"/> 
        /// </summary>
        public string Location { get; set; }


        /// <summary>
        /// Tipo de <see cref="DataSource"/> (  PLC o HMI  )
        /// </summary>
        public DataSourceType DataSourceType { get; set; }

        /// <summary>
        /// Cliente de Comunicacion de la <see cref="DataSource"/>  
        /// </summary>
        [NotMapped]
        public CommunicationClient CommunicationClient { get; set; }

        #endregion


        #region CONSTRUCTORS


        /// <summary>
        /// Requerido por EntityFramework
        /// </summary>
        protected DataSource() { }



        /// <summary>
        /// Inicializa un <see cref="DataSource"/>
        /// </summary>
        /// <param name="id">Identificador de la Fuente de Datos</param>
        /// <param name="code">Codigo Alfanumerico</param>
        /// <param name="inputsCounter">Cantidad de Entradas</param>
        /// <param name="outputsCounter">Cantidad de Salidas</param>
        public DataSource(Guid id, string code, int inputsCounter, int outputsCounter) : base(id)
        {

            Code = code;
            InputsCounter = inputsCounter;
            OutputsCounter = outputsCounter;
            Description = string.Empty;
            Location = string.Empty;
            DataSourceType = DataSourceType.PLC;


        }

        #endregion

    }
}
