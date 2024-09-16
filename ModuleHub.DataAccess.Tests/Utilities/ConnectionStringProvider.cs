#region   USINGS

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace ModuleHub.DataAccess.Tests.Utilities
{

    /// <summary>
    /// Proveedor de Cadena de Conexion con Base de Datos
    /// </summary>
    public static class ConnectionStringProvider
    {

        /// <summary>
        /// Obtiene cadena de conexion a usar en las Pruebas Unitarias
        /// </summary>
        /// <returns></returns>
        public static string GetConnectionString() => "Data Source=Data.sqlite";
    }
}
