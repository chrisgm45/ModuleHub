#region     USINGS

using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using ModuleHub.Contracts;
using ModuleHub.Contracts.Interfaces;
using ModuleHub.Domain;
using ModuleHub.Protos;
using ModuleHub.Protos.DataSource;


#endregion


namespace ModuleHub.GrpcService.Services

{

    public class DataSourceService : DataSource.DataSourceBase

    {

        public override Task<DataSourceDTO> CreateDataSource(CreateDataSourceRequest request, ServerCallContext context)
        {
            return base.CreateDataSource(request, context);
        }

        public override Task<NullableDataSourceDTO> GetDataSource(GetRequest request, ServerCallContext context)
        {
            return base.GetDataSource(request, context);
        }

        public override Task<DataSources> GetAllDataSources(Empty request, ServerCallContext context)
        {
            return base.GetAllDataSources(request, context);
        }

        public override Task<Empty> UpdateDataSource(DataSourceDTO request, ServerCallContext context)
        {
            return base.UpdateDataSource(request, context);
        }



        public override Task<Empty> DeleteDataSource(DeleteRequest request, ServerCallContext context)
        {
            return base.DeleteDataSource(request, context);
        }


        
        private readonly IDataSourceRepository _dataSourceRepository;
        private readonly IUnitOfWork _unitOfWork;
        /// <summary>
        /// Inyeccion de instancias de los Servicios
        /// </summary>
        /// <param name="dataSourceRepository">Repositorio de la <see cref="DataSource"/></param>
        /// <param name="unitOfWork">Unidad de Trabajo en Base de Datos</param>
        public DataSourceService (IDataSourceRepository dataSourceRepository, IUnitOfWork unitOfWork)
        {
            _dataSourceRepository = dataSourceRepository;
            _unitOfWork = unitOfWork;

        }



    }
}
