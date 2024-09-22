#region     USINGS

#endregion

namespace ModuleHub.Contracts
{

    /// <summary>
    /// Define las propiedades de la capa de abstracción de la lógica de acceso a datos.
    /// </summary>
    public interface IUnitOfWork
    {
        void SaveChanges();
    }
}
