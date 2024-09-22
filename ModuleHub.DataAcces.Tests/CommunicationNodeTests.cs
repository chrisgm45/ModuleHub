#region     USINGS

using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModuleHub.Contracts;
using ModuleHub.Contracts.Interfaces;
using ModuleHub.DataAccess.Contexts;
using ModuleHub.DataAccess.Repositories.Common;
using ModuleHub.DataAccess.Tests.Utilities;
using ModuleHub.Domain.Entities;
using System;
using System.Linq;

#endregion

namespace ModuleHub.DataAccess.Tests
{

    [TestClass]
    public class CommunicationNodeTest
    {


        public ICommunicationNodeRepository _communicationNodeRepository;
        public ICommunicationClientRepository _communicationClientRepository;
        public IDataSourceRepository _dataSourceRepository;
        public IUnitOfWork _unitOfWork;


        public CommunicationNodeTest()
        {
            ApplicationContext applicationContext = new ApplicationContext(ConnectionStringProvider.GetConnectionString());
            _communicationNodeRepository = new CommunicationNodeRepository(applicationContext);
            _communicationClientRepository = new CommunicationClientRepository(applicationContext);
            // _dataSourceRepository = new DataSourceRepository(applicationContext);
            _unitOfWork = new UnitOfWork(applicationContext);
        }


        #region *******************     TESTS      OPC NODE   ****************************



        [DataRow(0, "Label 1", "123.68.40.70")]
        [TestMethod]

        public void Can_Add_OPCNode(
            int communicationClientPosition,
            // int dataSourcePosition,
            string addressLabel,
            //string code,
            //int inputsCounter,
            // int outputsCounter,
            string addressIp)

        {
            //Arrange
            CommunicationClient? communicationClient = _communicationClientRepository.GetAllCommunicationClients().ElementAtOrDefault(communicationClientPosition);
            Assert.IsNotNull(communicationClient);

            // DataSource? dataSource = _dataSourceRepository.GetAllDataSources().ElementAtOrDefault(dataSourcePosition);
            //  Assert.IsNotNull(dataSource);

            Guid id = Guid.NewGuid();
            OPCNode oPCNode = new OPCNode(
                id,
                addressLabel,
                communicationClient);
            oPCNode.Id = id;

            //Execute
            _communicationNodeRepository.AddCommunicationNode(oPCNode);
            _unitOfWork.SaveChanges();

            //Assert
            OPCNode? loadedOPCNode = _communicationNodeRepository.GetCommunicationNodeById<OPCNode>(id);

            Assert.IsNotNull(loadedOPCNode);

        }






        [DataRow(0)]
        [TestMethod]
        public void Can_Get_OPCNode_By_Id(int position)
        {
            //Arrange
            var oPCNodes = _communicationNodeRepository.GetAllCommunicationNodes<OPCNode>().ToList();
            Assert.IsNotNull(oPCNodes);
            Assert.IsTrue(position < oPCNodes.Count);
            OPCNode oPCNodeToGet = oPCNodes[position];


            //Execute
            OPCNode? loadedOPCNode = _communicationNodeRepository.GetCommunicationNodeById<OPCNode>(oPCNodeToGet.Id);

            //Assert
            Assert.IsNotNull(loadedOPCNode);
        }




        [TestMethod]
        public void Cannot_Get_OPCNode_By_Invalid_Id()
        {
            //Arrange

            //Execute
            OPCNode? loadedOPCNode = _communicationNodeRepository.GetCommunicationNodeById<OPCNode>(Guid.Empty);

            //Assert
            Assert.IsNull(loadedOPCNode);
        }









        [DataRow(0)]
        [TestMethod]
        public void Can_Delete_OPCNode(int position)
        {

            //Arrange
            var oPCNodes = _communicationNodeRepository.GetAllCommunicationNodes<OPCNode>();
            Assert.IsNotNull(oPCNodes);
            var count = oPCNodes.Count();
            var oPCNode = oPCNodes.ElementAt(position);
            Assert.IsNotNull(oPCNode);

            //Execute
            _communicationNodeRepository.DeleteCommunicationNode(oPCNode);
            _unitOfWork.SaveChanges();

            //Assert
            oPCNodes = _communicationNodeRepository.GetAllCommunicationNodes<OPCNode>();
            Assert.AreEqual(count - 1, oPCNodes.Count());
            var deletedOPCNode = _communicationNodeRepository.GetCommunicationNodeById<OPCNode>(oPCNode.Id);
            Assert.IsNotNull(oPCNode);
        }





        [DataRow(0)]
        [TestMethod]

        public void Can_Update_OPCNode(int position)
        {
            //Arrange
            var oPCNodes = _communicationNodeRepository.GetAllCommunicationNodes<OPCNode>();
            Assert.IsNotNull(oPCNodes);
            var oPCNode = oPCNodes.ElementAt(position);
            Assert.IsNotNull(oPCNode);

            //Execute

            oPCNode.AddressLabel = "Label 1.1";
            _communicationNodeRepository.UpdateCommunicationNode(oPCNode);
            _unitOfWork.SaveChanges();

            //Assert
            var updatedOPCNode = _communicationNodeRepository.GetCommunicationNodeById<OPCNode>(oPCNode.Id);

            Assert.IsNotNull(updatedOPCNode);
            Assert.AreEqual(updatedOPCNode.AddressLabel, oPCNode.AddressLabel);

        }
        #endregion



        #region   *******************     TESTS    MODBUS NODE   ****************************


        [DataRow(0, "Modbus 1", 4, "12.8.0.70")]
        [TestMethod]

        public void Can_Add_ModbusNode(
            int communicationClientPosition,
            // int dataSourcePosition,
            string name,
            int recordSource,
            // string code,
            //  int inputsCounter,
            //  int outputsCounter,
            string addressIp)

        {
            //Arrange
            CommunicationClient? communicationClient = _communicationClientRepository.GetAllCommunicationClients().ElementAtOrDefault(communicationClientPosition);
            Assert.IsNotNull(communicationClient);

            //   DataSource? dataSource = _dataSourceRepository.GetAllDataSources().ElementAtOrDefault(dataSourcePosition);
            //   Assert.IsNotNull(dataSource);

            Guid id = Guid.NewGuid();
            ModbusNode modbusNode = new ModbusNode(
                id,
                name,
                recordSource,
                communicationClient);
            modbusNode.Id = id;

            //Execute
            _communicationNodeRepository.AddCommunicationNode(modbusNode);
            _unitOfWork.SaveChanges();

            //Assert
            ModbusNode? loadedModbusNode = _communicationNodeRepository.GetCommunicationNodeById<ModbusNode>(id);

            Assert.IsNotNull(loadedModbusNode);

        }






        [DataRow(0)]
        [TestMethod]
        public void Can_Get_ModbusNode_By_Id(int position)
        {
            //Arrange
            var modbusNodes = _communicationNodeRepository.GetAllCommunicationNodes<ModbusNode>().ToList();
            Assert.IsNotNull(modbusNodes);
            Assert.IsTrue(position < modbusNodes.Count);
            ModbusNode modbusNodeToGet = modbusNodes[position];


            //Execute
            ModbusNode? loadedModbusNode = _communicationNodeRepository.GetCommunicationNodeById<ModbusNode>(modbusNodeToGet.Id);

            //Assert
            Assert.IsNotNull(loadedModbusNode);
        }




        [TestMethod]
        public void Cannot_Get_ModbusNode_By_Invalid_Id()
        {
            //Arrange

            //Execute
            ModbusNode? loadedModbusNode = _communicationNodeRepository.GetCommunicationNodeById<ModbusNode>(Guid.Empty);

            //Assert
            Assert.IsNull(loadedModbusNode);
        }









        [DataRow(0)]
        [TestMethod]
        public void Can_Delete_ModbusNode(int position)
        {

            //Arrange
            var modbusNodes = _communicationNodeRepository.GetAllCommunicationNodes<ModbusNode>();
            Assert.IsNotNull(modbusNodes);
            var count = modbusNodes.Count();
            var modbusNode = modbusNodes.ElementAt(position);
            Assert.IsNotNull(modbusNode);

            //Execute
            _communicationNodeRepository.DeleteCommunicationNode(modbusNode);
            _unitOfWork.SaveChanges();

            //Assert
            modbusNodes = _communicationNodeRepository.GetAllCommunicationNodes<ModbusNode>();
            Assert.AreEqual(count - 1, modbusNodes.Count());
            var deletedModbusNode = _communicationNodeRepository.GetCommunicationNodeById<ModbusNode>(modbusNode.Id);
            Assert.IsNotNull(modbusNode);
        }





        [DataRow(0)]
        [TestMethod]

        public void Can_Update_ModbusNode(int position)
        {
            //Arrange
            var modbusNodes = _communicationNodeRepository.GetAllCommunicationNodes<ModbusNode>();
            Assert.IsNotNull(modbusNodes);
            var modbusNode = modbusNodes.ElementAt(position);
            Assert.IsNotNull(modbusNode);

            //Execute

            modbusNode.Name = "Modbus 3.1";
            _communicationNodeRepository.UpdateCommunicationNode(modbusNode);
            _unitOfWork.SaveChanges();

            //Assert
            var updatedModbusNode = _communicationNodeRepository.GetCommunicationNodeById<ModbusNode>(modbusNode.Id);

            Assert.IsNotNull(updatedModbusNode);
            Assert.AreEqual(updatedModbusNode.Name, modbusNode.Name);

        }



        #endregion


    }
}
