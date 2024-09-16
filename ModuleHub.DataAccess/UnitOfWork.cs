#region    USINGS

using Microsoft.EntityFrameworkCore;
using ModuleHub.Contracts;
using ModuleHub.DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion


namespace ModuleHub.DataAccess
{
    /// <summary>
    /// Implementacion de la IUnitOfWork
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {

        /// <summary>
        /// Recibe el Contexto de la Base de Datos
        /// </summary>
        private readonly ApplicationContext _applicationContext ;


        /// <summary>
        /// Analiza la Posibilidad de Conexion con la Base de Datos
        /// </summary>
        public UnitOfWork (ApplicationContext applicationContext)
        {

            _applicationContext = applicationContext;

            // Comprobando Existencia de Base de Datos
            if (!applicationContext.Database.CanConnect())
                applicationContext.Database.Migrate();
        }



        /// <summary>
        /// Guarda los cambios realizados en el contexto de la Base de Datos
        /// </summary>
        public void SaveChanges()
        {
            _applicationContext.SaveChanges();
        }


    }
}
