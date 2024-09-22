#region   USINGS

using ModuleHub.Domain.Entities.Common;

#endregion

namespace ModuleHub.Domain.Entities
{

    /// <summary>
    /// Modela un Nodo Tipo MODBUS como Nodo de Comunicacion
    /// </summary>
    public class ModbusNode : CommunicationNode
    {

        #region    PROPERTIES


        /// <summary>
        /// Nombre del <see cref="ModbusNode"/>
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// Registro a partir del cual el <see cref="ModbusNode"/> va a obtener la info
        /// </summary>
        public int RecordSource { get; set; }


        /// <summary>
        /// Cantidad de Registros a leer por el <see cref="ModbusNode"/>
        /// </summary>
        public int RecordToRead { get; set; }



        #endregion


        #region     CONSTRUCTORS


        /// <summary>
        /// Requerido por EntityFramework
        /// </summary>
        protected ModbusNode() { }



        /// <summary>
        /// Inicializa un <see cref="ModbusNode"/>
        /// </summary>
        /// <param name="name"> Nombre del <see cref="ModbusNode"/> </param>
        /// <param name="recordSource"> Registro del cual obtiene la info el <see cref="ModbusNode"/>/></param>
        /// <param name="communicationClient"> Cliente al que le pertenece el <see cref="ModbusNode"/>/></param>
        public ModbusNode(Guid id, string name, int recordSource, CommunicationClient communicationClient) :
            base(id, communicationClient)
        {
            Name = name;
            RecordSource = recordSource;
            RecordToRead = 0;
            CommunicationClient = communicationClient;
            CommunicationClientId = communicationClient.Id;
        }


        #endregion

    }
}