#region    USINGS

using ModuleHub.Contracts.Interfaces;
using ModuleHub.Contracts;
using ModuleHub.DataAccess.Contexts;
using ModuleHub.DataAccess.Repositories.Common;
using ModuleHub.DataAccess.Tests.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModuleHub.Domain.Entities;

#endregion

namespace ModuleHub.DataAccess.Tests
{
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


        [DataRow("Modbus 1",5, 2)]

        [TestMethod]
        public void Can_Add_DataSource(
            string code,
            int inputsCounter,
            int outputsCounter)
        {
            //Arrange
            Guid id = Guid.NewGuid();
            DataSource dataSource = new DataSource (id, code, inputsCounter, outputsCounter);
            dataSource.id = id;

            //Execute
            _dataSourceRepository.AddDataSource(dataSource);
            _unitOfWork.SaveChanges();

            //Assert
            DataSource? loadedDataSource = _dataSourceRepository.GetDataSourceById(id);
            Assert.IsNotNull(loadedDataSource);













            public void Can_Get_CommunicationNode_By_Id(int position)

        {

            //Arrange


            //Execute



            //Assert


        }



    }
}
