#region    USINGS

using ModuleHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace ModuleHub.Contracts.Interfaces
{

    /// <summary>
    /// CRUDs de Persistencia en Base de Datos de la <see cref="DataSource"/>
    /// </summary>
    public interface IDataSourceRepository
    {


        /// <summary>
        /// Añade una <see cref="DataSource"/> a Base de Datos
        /// </summary>
        /// <param name="dataSource">Fuente de Datos</param>
        void AddDataSource(DataSource dataSource);



        /// <summary>
        /// Obtiene por su "ID" una <see cref="DataSource"/> de Base de Datos
        /// </summary>
        /// <param name="id">Identificador de la <see cref="DataSource"/></param>
        /// <returns></returns>
        DataSource? GetDataSourceById (Guid id);



        /// <summary>
        /// Obtiene todas las <see cref="DataSource"/> de la Base de Datos
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DataSource> GetAllDataSources();



        /// <summary>
        /// Actualiza una <see cref="DataSource"/> en Base de Datos
        /// </summary>
        /// <param name="dataSource">Fuente de Datos</param>
        void UpdateDataSource(DataSource dataSource);



        /// <summary>
        /// Borra de la Base de Datos una <see cref="DataSource"/>
        /// </summary>
        /// <param name="dataSource">Fuente de Datos</param>
        void DeleteDataSource(DataSource dataSource);

    }
}
