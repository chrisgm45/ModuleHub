#region   USINGS

using ModuleHub.Application.Abstract;
using ModuleHub.Contracts;
using ModuleHub.Contracts.Interfaces;
using ModuleHub.DataAccess.Repositories.Common;
using ModuleHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion


namespace ModuleHub.Application.DataSourcesCQRS.Commands.CreateDataSource
{
    public class CreateDataSourceCommandHandler
       : ICommandHandler<CreateDataSourceCommand, DataSource>
    {
        private readonly IDataSourceRepository _dataSourceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateDataSourceCommandHandler(
            IDataSourceRepository dataSourceRepository,
            IUnitOfWork unitOfWork)
        {
            _dataSourceRepository = dataSourceRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<DataSource> Handle(CreateDataSourceCommand request, CancellationToken cancellationToken)
        {
            DataSource result = new DataSource(
                Guid.NewGuid(),
                request.Code,
                request.InputsCounter,
                request.OutputsCounter);

            _dataSourceRepository.AddDataSource(result);
            _unitOfWork.SaveChanges();

            return Task.FromResult(result);
        }
    }
}
