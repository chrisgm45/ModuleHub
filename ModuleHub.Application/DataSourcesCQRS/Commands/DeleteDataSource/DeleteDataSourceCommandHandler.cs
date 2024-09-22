#region    USINGS

using ModuleHub.Application.Abstract;
using ModuleHub.Application.DataSources.Commands.DeleteDataSource;
using ModuleHub.Contracts;
using ModuleHub.Contracts.Interfaces;
using ModuleHub.DataAccess.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion


namespace ModuleHub.Application.DataSourcesCQRS.Commands.DeleteDataSource
{
    public class DeleteDataSourceCommandHandler
        : ICommandHandler<DeleteDataSourceCommand>
    {
        private readonly IDataSourceRepository _dataSourceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteDataSourceCommandHandler(
            IDataSourceRepository dataSourceRepository,
            IUnitOfWork unitOfWork)
        {
            _dataSourceRepository = dataSourceRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(DeleteDataSourceCommand request, CancellationToken cancellationToken)
        {
            var dataSourceToDelete = _dataSourceRepository.GetDataSourceById(request.id);
            if (dataSourceToDelete is null)
                return Task.CompletedTask;
            _dataSourceRepository.DeleteDataSource(dataSourceToDelete);
            _unitOfWork.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
