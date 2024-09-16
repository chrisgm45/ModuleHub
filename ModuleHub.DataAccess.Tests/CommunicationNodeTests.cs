#region   USINGS

using ModuleHub.Contracts;
using ModuleHub.Contracts.Interfaces;
using ModuleHub.DataAccess.Contexts;
using ModuleHub.DataAccess.Repositories.Common;
using ModuleHub.DataAccess.Tests.Utilities;
using ModuleHub.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace ModuleHub.DataAccess.Tests
{

    [TestClass]
    public class CommunicationNodeTests
    {
        
        private ICommunicationNodeRepository _communicationNodeRepository;

        private ICommunicationClientRepository _communicationClientRepository;

        private IUnitOfWork _unitOfWork;



        public CommunicationNodeTests()
        {
            ApplicationContext applicationContext = new ApplicationContext 
                (ConnectionStringProvider.GetConnectionString() );
            
            _communicationNodeRepository = new CommunicationNodeRepository ( applicationContext);
            _communicationClientRepository = new CommunicationClientRepository(applicationContext);
            _unitOfWork = new UnitOfWork ( applicationContext );

        }


        [DataRow(0,"Modbus 1")]


        [TestMethod]
        public void Can_Get_CommunicationNode_By_Id( int position)
                        
             {
                     
             //Arrange

             
            //Execute



            //Assert
                   

             }






    }
}
