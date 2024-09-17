#region    USINGS

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System;
using ModuleHub.DataAccess.Contexts;
using ModuleHub.Domain.Entities;
using ModuleHub.Domain.Utilities.Types;

#endregion

namespace ModuleHub.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // contexto creado para interactuar con la Base Datos
            ApplicationContext applicationContext = new ApplicationContext("DataSource = ModuleHub_DB.sqlite");

            //comprobando exitencia de la base de datos
            if (!applicationContext.Database.CanConnect())
            {
                // si no existe BD entonces se crea ahora a partir de la migracion realizada
                applicationContext.Database.Migrate();
            }


            #region    ************   CRUDs   ***************


            #region    CREATE

            Console.WriteLine("********************    CREATE    ***************************");
            Console.WriteLine("");
            Console.WriteLine("       Creado con Exito");

            // Creando Fuentes de datos
            DataSource dataSource1 = new DataSource
                (Guid.NewGuid(), "code1", 3, 2);
            DataSource dataSource2 = new DataSource
                (Guid.NewGuid(), "code2", 1, 1);


            // Creando Clientes de Comunicacion
            CommunicationClient communicationClient1 = new CommunicationClient
                (Guid.NewGuid(), "68.96.88.4", dataSource1);
            CommunicationClient communicationClient2 = new CommunicationClient
                (Guid.NewGuid(), "88.100.48.2", dataSource2);


            // Creando Nodos Modbus (Hardwares)
            ModbusNode modbusNode1 = new ModbusNode
                (Guid.NewGuid(), "ModBus_1", 1, communicationClient1);
            ModbusNode modbusNode2 = new ModbusNode
                (Guid.NewGuid(), "ModBus_2", 3, communicationClient2);


            // Creando Nodos OPC (Softwares)
            OPCNode oPCNode1 = new OPCNode
                (Guid.NewGuid(), "68.96.88.4", communicationClient1);
            OPCNode oPCNode2 = new OPCNode
                (Guid.NewGuid(), "88.100.48.2", communicationClient2);





            //                SALVA en BASE DATOS


            //Añadiendo Fuentes de Datos a BD
            applicationContext.Set<DataSource>().Add(dataSource1);
            applicationContext.Set<DataSource>().Add(dataSource2);
            // Guardar Modificaciones Realizadas
            applicationContext.SaveChanges();



            //Añadiendo Clientes de Comunicacion a BD
            applicationContext.Set<CommunicationClient>().Add(communicationClient1);
            applicationContext.Set<CommunicationClient>().Add(communicationClient2);
            // Guardar Modificaciones Realizadas
            applicationContext.SaveChanges();



            //Añadiendo Nodos Modbus a BD
            applicationContext.Set<ModbusNode>().Add(modbusNode1);
            applicationContext.Set<ModbusNode>().Add(modbusNode2);
            // Guardar Modificaciones Realizadas
            applicationContext.SaveChanges();



            //Añadiendo Nodos OPC a BD
            applicationContext.Set<OPCNode>().Add(oPCNode1);
            applicationContext.Set<OPCNode>().Add(oPCNode2);
            // Guardar Modificaciones Realizadas
            applicationContext.SaveChanges();


            #endregion


            #region     READ

            Console.WriteLine("");
            Console.WriteLine("********************    GET  ID    ***************************");
            Console.WriteLine("");
            Console.WriteLine("");


            //  Obteniendo  ID desde Base Datos
            DataSource? dataSourceOfClient1 = applicationContext
                .Set<DataSource>()
                .FirstOrDefault(d => d.Id == communicationClient1.DataSourceId);

            //  Obteniendo  ID desde Base Datos
            DataSource? dataSourceOfClient2 = applicationContext
                .Set<DataSource>()
                .FirstOrDefault(d => d.Id == communicationClient2.DataSourceId);




            //  Obteniendo  ID desde Base Datos
            CommunicationClient? communicationClientOfModbusNodes1 = applicationContext
                .Set<CommunicationClient>()
                .FirstOrDefault(c => c.Id == modbusNode1.CommunicationClientId);

            //  Obteniendo  ID desde Base Datos
            CommunicationClient? communicationClientOfModbusNodes2 = applicationContext
                .Set<CommunicationClient>()
                .FirstOrDefault(c => c.Id == modbusNode2.CommunicationClientId);





            //  Obteniendo  ID desde Base Datos
            CommunicationClient? communicationClientOfOPCNodes1 = applicationContext
                .Set<CommunicationClient>()
                .FirstOrDefault(c => c.Id == oPCNode1.CommunicationClientId);

            //  Obteniendo  ID desde Base Datos
            CommunicationClient? communicationClientOfOPCNodes2 = applicationContext
                .Set<CommunicationClient>()
                .FirstOrDefault(c => c.Id == oPCNode2.CommunicationClientId);


            Console.WriteLine("Identificadores obtenidos con  EXITO");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");


            #endregion


            #region      UPDATE


            Console.WriteLine("");
            Console.WriteLine("********************    UPDATE    ***************************");
            Console.WriteLine("");

            // Modificando Aspectos de Fuente de Datos en la Base de Datos
            var dataSources = applicationContext.Set<DataSource>().ToList();

            foreach (var loadedDataSource in dataSources)
            {
                loadedDataSource.DataSourceType = DataSourceType.HMI;
                applicationContext.Set<DataSource>().Update(loadedDataSource);
            }
            applicationContext.SaveChanges();

            Console.WriteLine("Nuevo tipo de Fuente de Datos");







            // Modificando Aspectos del Cliente de Comunicacion en la Base de Datos
            var communicationClients = applicationContext.Set<CommunicationClient>().ToList();

            foreach (var loadedCommunicationClient in communicationClients)
            {
                loadedCommunicationClient.ConnectionPort = "8";
                applicationContext.Set<CommunicationClient>().Update(loadedCommunicationClient);
            }

            applicationContext.SaveChanges();

            Console.WriteLine("Nuevo Puerto de Conexion del Cliente de Comunicacion");







            // Modificando Aspectos del Nodo MODBUS en la Base de Datos
            var modbusNodes = applicationContext.Set<ModbusNode>().ToList();

            foreach (var loadedModbusNode in modbusNodes)
            {
                loadedModbusNode.RecordToRead = 2;
                loadedModbusNode.RecordSource = 4;
                applicationContext.Set<ModbusNode>().Update(loadedModbusNode);
            }

            applicationContext.SaveChanges();

            Console.WriteLine("Nuevo Registro para obtener info por Nodo Modbus ");








            // Modificando Aspectos del Nodo MODBUS en la Base de Datos
            var opcNodes = applicationContext.Set<OPCNode>().ToList();

            foreach (var loadedOPCNode in opcNodes)
            {
                loadedOPCNode.AddressLabel = "100.90.80.5";
                applicationContext.Set<OPCNode>().Update(loadedOPCNode);
            }

            applicationContext.SaveChanges();

            Console.WriteLine("Nueva direccion a consumir por Nodo OPC ");


            #endregion


            #region        DELETE

            Console.WriteLine("");
            Console.WriteLine("********************    DELETE    ***************************");
            Console.WriteLine("");

            //          Eliminando de Base de Datos



            //  Eliminando un Nodo OPC del Soporte de Datos
            applicationContext.CommunicationNodes.Remove(oPCNode1);
            applicationContext.SaveChanges();

            OPCNode? deletedOPCNode = applicationContext.Set<OPCNode>()
                .FirstOrDefault(o => o.Id == oPCNode1.Id);
            if (deletedOPCNode is null)
                Console.WriteLine("Nodo OPC eliminado con Exito");






            //  Eliminando un Nodo Modbus del Soporte de Datos
            applicationContext.CommunicationNodes.Remove(modbusNode1);
            applicationContext.SaveChanges();

            ModbusNode? deletedModbusNode = applicationContext.Set<ModbusNode>()
                .FirstOrDefault(m => m.Id == modbusNode1.Id);
            if (deletedModbusNode is null)
                Console.WriteLine("Nodo MODBUS eliminado con Exito");







            //  Eliminando un Cliente de Comunicacion del Soporte de Datos
            applicationContext.CommunicationClients.Remove(communicationClient1);
            applicationContext.SaveChanges();

            CommunicationClient? deletedCommunicationClient = applicationContext.Set<CommunicationClient>()
                .FirstOrDefault(c => c.Id == communicationClient1.Id);
            if (deletedCommunicationClient is null)
                Console.WriteLine("Cliente de Comunicacion eliminado con Exito");








            //  Eliminando una Fuente de Datos del Soporte de Datos
            applicationContext.DataSources.Remove(dataSource1);
            applicationContext.SaveChanges();

            DataSource? deletedDataSource = applicationContext.Set<DataSource>()
                .FirstOrDefault(d => d.Id == dataSource1.Id);
            if (deletedDataSource is null)
                Console.WriteLine("Fuente de Datos eliminada con Exito");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("                    __   FIN   __");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");





















            #endregion


            #endregion

        }
    }
}