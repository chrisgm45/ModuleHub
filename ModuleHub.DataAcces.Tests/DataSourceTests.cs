#region      USINGS

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModuleHub.DataAccess.Tests.Utilities;
using ModuleHub.Contracts.Interfaces;
using ModuleHub.Contracts;
using ModuleHub.DataAccess.Contexts;
using ModuleHub.DataAccess.Repositories.Common;
using ModuleHub.Domain.Entities;

#endregion

namespace ModuleHub.DataAccess.Tests
{

    [TestClass]
    public class DataSourceTests


    {
        private IDataSourceRepository _dataSourceRepository;
        private IUnitOfWork _unitOfWork;




        public DataSourceTests()
        {
            ApplicationContext applicationContext = new ApplicationContext
                (ConnectionStringProvider.GetConnectionString());

            _dataSourceRepository = new DataSourceRepository(applicationContext);
            _unitOfWork = new UnitOfWork(applicationContext);

        }






        [DataRow("PLC 1", 5, 2)]
        [TestMethod]
        public void Can_Add_DataSource(
            string code,
            int inputsCounter,
            int outputsCounter)

        {
            //Arrange
            Guid id = Guid.NewGuid();
            DataSource dataSource = new DataSource(id, code, inputsCounter, outputsCounter);
            dataSource.Id = id;

            //Execute
            _dataSourceRepository.AddDataSource(dataSource);
            _unitOfWork.SaveChanges();

            //Assert
            DataSource? loadedDataSource = _dataSourceRepository.GetDataSourceById(id);
            Assert.IsNotNull(loadedDataSource);

        }



        [DataRow(0)]
        [TestMethod]

        public void Can_Get_DataSource_By_Id(int position)
        {
            //Arrange
            var dataSources = _dataSourceRepository.GetAllDataSources().ToList();
            Assert.IsNotNull(dataSources);
            Assert.IsTrue(position < dataSources.Count);
            DataSource dataSourceToGet = dataSources[position];

            //Execute
            DataSource? loadedDataSource = _dataSourceRepository.GetDataSourceById(dataSourceToGet.Id);

            //Assert
            Assert.IsNotNull(loadedDataSource);

        }

        [TestMethod]
        public void Cannot_Get_DataSource_By_Invalid_Id()
        {
            //Arrange

            //Execute
            DataSource? loadedDataSource = _dataSourceRepository.GetDataSourceById(Guid.Empty);

            //Assert
            Assert.IsNull(loadedDataSource);
        }








        [DataRow(0)]
        [TestMethod]

        public void Can_Delete_DataSource(int position)
        {
            //Arrange
            var dataSources = _dataSourceRepository.GetAllDataSources();
            Assert.IsNotNull(dataSources);
            var count = dataSources.Count();
            var dataSource = dataSources.ElementAt(position);
            Assert.IsNotNull(dataSource);

            //Execute
            _dataSourceRepository.DeleteDataSource(dataSource);
            _unitOfWork.SaveChanges();

            //Asert
            dataSources = _dataSourceRepository.GetAllDataSources();
            Assert.AreEqual(count - 1, dataSources.Count());
            var deletedDataSource = _dataSourceRepository.GetDataSourceById(dataSource.Id);
            Assert.IsNotNull(dataSource);

        }








        [DataRow(0)]
        [TestMethod]

        public void Can_Update_DataSource(int position)
        {
            //Arrange
            var dataSources = _dataSourceRepository.GetAllDataSources();
            Assert.IsNotNull(dataSources);
            var dataSource = dataSources.ElementAt(position);
            Assert.IsNotNull(dataSource);

            //Excecute
            dataSource.Code = "PLC 1.1";
            _dataSourceRepository.UpdateDataSource(dataSource);
            _unitOfWork.SaveChanges();

            //Asert
            var updatedDataSource = _dataSourceRepository.GetDataSourceById(dataSource.Id);
            Assert.IsNotNull(updatedDataSource);
            Assert.AreEqual(updatedDataSource.Code, dataSource.Code);

        }






    }
}
