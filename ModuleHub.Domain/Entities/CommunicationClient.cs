#region USINGS

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModuleHub.Domain.Entities.Common;
using ModuleHub.Domain.Entities;
using ModuleHub.Domain.Utilities.Types;

#endregion

namespace ModuleHub.Domain.Entities
{

    /// <summary>
    /// Modela un <see cref="CommunicationClient"/> 
    /// </summary>
    public class CommunicationClient : Entity
    {

        #region    PROPERTIES

        /// <summary>
        /// Direccion IP del <see cref="CommunicationClient"/> 
        /// </summary>
        [Required]
        public string AddressIp { get; set; }


        /// <summary>
        /// Puerto de Conexion del <see cref="CommunicationClient"/> 
        /// </summary>
        public string ConnectionPort { get; set; }


        /// <summary>
        /// Tipo de <see cref="CommunicationClient"/> 
        /// </summary>
        CommunicationClientType CommunicationClientType { get; set; }



        /// <summary>
        /// Identificador de la Fuente de Datos a la que pertenece el <see cref="CommunicationClient"/> 
        /// </summary>
        public Guid DataSourceId { get; set; }



        /// <summary>
        /// (Relacion 1 a 1) Fuente de datos del <see cref="CommunicationClient"/> 
        /// </summary>
        [NotMapped]
        public virtual DataSource DataSource { get; set; }


        /// <summary>
        /// (Relacion 1 a muchos) Lista de Nodos de Comunicacion del <see cref="CommunicationClient"/>
        /// </summary>
        [NotMapped]
        public List<CommunicationNode> CommunicationNodes { get; set; }


        #endregion


        #region   CONSTRUCTORS


        /// <summary>
        /// Requerido por EntityFramework
        /// </summary>
        protected CommunicationClient() { }


        /// <summary>
        /// Inicializa un <see cref="CommunicationClient"/>
        /// </summary>
        /// <param name="id">Identificador del <see cref="CommunicationClient"/></param>
        /// <param name="addresIp">Direccion Ip</param>
        /// <param name="dataSource">Fuente de Datos relacionada</param>
        public CommunicationClient(Guid id, string addresIp, DataSource dataSource) : base(id)
        {

            AddressIp = addresIp;
            ConnectionPort = string.Empty;
            CommunicationClientType = CommunicationClientType.MODBUS;
            DataSource = dataSource;
            DataSourceId = dataSource.Id;


        }


        #endregion

    }
}
