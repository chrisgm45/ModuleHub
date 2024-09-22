#region   USINGS

using Microsoft.EntityFrameworkCore;
using ModuleHub.Contracts;
using ModuleHub.DataAccess.Contexts;

#endregion

namespace ModuleHub.DataAccess
{


    /// <summary>
    /// Implementacion de la interfaz de Unidad de Trabajo
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {

        /// <summary>
        ///Almacena para poder utilizarlo para salvar los cambios en Base de Datos
        /// </summary>
        private readonly ApplicationContext _applicationContext;

        /// <summary>
        /// Comprueba si existe la Base de Datos
        /// </summary>
        /// <param name="applicationContext"> Contexto de la Base de Datos </param>
        public UnitOfWork(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
            if (!applicationContext.Database.CanConnect())
                applicationContext.Database.Migrate();
        }



        /// <summary>
        /// Guarda los cambios realizados en Base de Datos
        /// </summary>
        public void SaveChanges()
        {
            _applicationContext.SaveChanges();
        }
    }
}