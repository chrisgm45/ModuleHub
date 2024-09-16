#region     USINGS

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
