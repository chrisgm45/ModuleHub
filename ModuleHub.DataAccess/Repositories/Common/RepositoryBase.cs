#region    USINGS

using ModuleHub.DataAccess.Contexts;

#endregion


namespace ModuleHub.DataAccess.Repositories.Common
{

    /// <summary>
    /// Clase Base para los Repositorios del Proyecto
    /// </summary>
    public abstract class RepositoryBase
    {

        /// <summary>
        /// Contexto de la Base de Datos
        /// </summary>
        protected ApplicationContext _applicationContext;

        protected RepositoryBase(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
    }
}
