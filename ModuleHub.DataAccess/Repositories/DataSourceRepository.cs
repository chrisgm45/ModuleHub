﻿#region   USINGS

using ModuleHub.Contracts.Interfaces;
using ModuleHub.DataAccess.Contexts;
using ModuleHub.Domain.Entities;

#endregion


namespace ModuleHub.DataAccess.Repositories.Common
{


    /// <summary>
    /// CRUDs para el Repositorio de la Entidad <see cref="DataSource"/> 
    /// </summary>
    public class DataSourceRepository : RepositoryBase, IDataSourceRepository
    {


        /// <summary>
        /// Constructor del Contexto para el Repositorio Base
        /// </summary>
        /// <param name="applicationContext">Contexto de la Base de Datos</param>
        public DataSourceRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }



        /// <summary>
        /// Añade una <see cref="DataSource"/>
        /// </summary>
        /// <param name="dataSource"> Fuente de Datos </param>
        public void AddDataSource(DataSource dataSource)
        {
            _applicationContext.DataSources.Add(dataSource);
        }



        /// <summary>
        /// Elimina una <see cref="DataSource"/>
        /// </summary>
        /// <param name="dataSource"> Fuente de Datos </param>
        public void DeleteDataSource(DataSource dataSource)
        {
            _applicationContext.DataSources.Remove(dataSource);
        }



        /// <summary>
        /// Obtiene todas las <see cref="DataSource"/> de la Base de Datos
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DataSource> GetAllDataSources()
        {
            return _applicationContext.DataSources.ToList();
        }



        /// <summary>
        /// Obtiene una <see cref="DataSource"/> por su Identificador
        /// </summary>
        /// <param name="id">Identificador de la <see cref="DataSource"/></param>
        /// <returns></returns>
        public DataSource? GetDataSourceById(Guid id)
        {
            return _applicationContext.DataSources.FirstOrDefault(x => x.Id == id);
        }



        /// <summary>
        /// Actualiza una <see cref="DataSource"/>
        /// </summary>
        /// <param name="dataSource"> Fuente de Datos </param>
        public void UpdateDataSource(DataSource dataSource)
        {
            _applicationContext.DataSources.Update(dataSource);
        }




    }
}
