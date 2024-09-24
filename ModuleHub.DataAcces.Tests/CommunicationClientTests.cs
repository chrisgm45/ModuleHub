#region      USINGS

using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModuleHub.Contracts;
using ModuleHub.Contracts.Interfaces;
using ModuleHub.DataAccess.Contexts;
using ModuleHub.DataAccess.Repositories.Common;
using ModuleHub.DataAccess.Tests.Utilities;
using ModuleHub.Domain.Entities;
using ModuleHub.Domain.Utilities.Types;
using System;
using System.Linq;

#endregion

namespace ModuleHub.DataAccess.Tests
{


    [TestClass]
    public class CommunicationClientTests
    {



        public ICommunicationClientRepository _communicationClientRepository;
        public IDataSourceRepository _dataSourceRepository;
        public IUnitOfWork _unitOfWork;


        public CommunicationClientTests()
        {
            ApplicationContext applicationContext = new ApplicationContext(ConnectionStringProvider.GetConnectionString());
            _communicationClientRepository = new CommunicationClientRepository(applicationContext);
            _dataSourceRepository = new DataSourceRepository(applicationContext);
            _unitOfWork = new UnitOfWork(applicationContext);
        }





        [DataRow(0, "123.68.40.70", "PLC ", 4, 3)]
        [TestMethod]

        public void Can_Add_CommunicationClient(

            int dataSourcePosition,
            string addressIp,
            string code,
            int inputsCounter,
            int outputsCounter
            )

        {
            //Arrange
            DataSource? dataSource = _dataSourceRepository.GetAllDataSources().ElementAtOrDefault(dataSourcePosition);
            Assert.IsNotNull(dataSource);

            Guid id = Guid.NewGuid();
            CommunicationClient communicationClient = new CommunicationClient(
                id,
                addressIp,
                dataSource);
            communicationClient.Id = id;

            //Execute
            _communicationClientRepository.AddCommunicationClient(communicationClient);
            _unitOfWork.SaveChanges();

            //Assert
            CommunicationClient? loadedCommunicationClient = _communicationClientRepository.GetCommunicationClientById(id);
            Assert.IsNotNull(loadedCommunicationClient);

        }





        [DataRow(0)]
        [TestMethod]
        public void Can_Get_CommunicationClient_By_Id(int position)
        {
            //Arrange
            var communicationClient = _communicationClientRepository.GetAllCommunicationClients().ToList();
            Assert.IsNotNull(communicationClient);
            Assert.IsTrue(position < communicationClient.Count);
            CommunicationClient communicationClientToGet = communicationClient[position];


            //Execute
            CommunicationClient? loadedCommunicationClient = _communicationClientRepository.GetCommunicationClientById(communicationClientToGet.Id);

            //Assert
            Assert.IsNotNull(loadedCommunicationClient);
        }


        [TestMethod]
        public void Cannot_Get_CommunicationClient_By_Invalid_Id()
        {
            //Arrange

            //Execute
            CommunicationClient? loadedCommunicationClient = _communicationClientRepository.GetCommunicationClientById(Guid.Empty);

            //Assert
            Assert.IsNull(loadedCommunicationClient);
        }






        [DataRow(0)]
        [TestMethod]
        public void Can_Delete_CommunicationClient(int position)
        {

            //Arrange
            var communicationClients = _communicationClientRepository.GetAllCommunicationClients();
            Assert.IsNotNull(communicationClients);
            var count = communicationClients.Count();
            var communicationClient = communicationClients.ElementAt(position);
            Assert.IsNotNull(communicationClient);

            //Execute
            _communicationClientRepository.DeleteCommunicationClient(communicationClient);
            _unitOfWork.SaveChanges();

            //Assert
            communicationClients = _communicationClientRepository.GetAllCommunicationClients();
            Assert.AreEqual(count - 1, communicationClients.Count());
            var deletedCommunicationClient = _communicationClientRepository.GetCommunicationClientById(communicationClient.Id);
            Assert.IsNotNull(communicationClient);
        }







        [DataRow(0)]
        [TestMethod]

        public void Can_Update_CommunicationClient(int position)
        {
            //Arrange
            var communicationClients = _communicationClientRepository.GetAllCommunicationClients();
            Assert.IsNotNull(communicationClients);
            var communicationClient = communicationClients.ElementAt(position);
            Assert.IsNotNull(communicationClient);

            //Execute

            communicationClient.ConnectionPort = "3-E";
            _communicationClientRepository.UpdateCommunicationClient(communicationClient);
            _unitOfWork.SaveChanges();

            //Assert
            var updatedCommunicationClient = _communicationClientRepository.GetCommunicationClientById(communicationClient.Id);
            Assert.IsNotNull(updatedCommunicationClient);
            Assert.AreEqual(updatedCommunicationClient.ConnectionPort, communicationClient.ConnectionPort);

        }





    }
}
