#region    USINGS

using ModuleCentralizationIIoT.Application.MessageCQRS.Commands.UpdateMessage;
using ModuleHub.Application.Abstract;
using ModuleHub.Contracts;
using ModuleHub.Contracts.Interfaces;
using ModuleHub.DataAccess.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace ModuleHub.Application.DataSourcesCQRS.Commands.UpdateDataSource
{
    public class UpdateDataSourceCommandHandler
           : ICommandHandler<UpdateDataSourceCommand>
    {
        private readonly IDataSourceRepository _dataSourceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateDataSourceCommandHandler(
            IDataSourceRepository dataSourceRepository,
            IUnitOfWork unitOfWork)
        {
            _dataSourceRepository = dataSourceRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(UpdateDataSourceCommand request, CancellationToken cancellationToken)
        {
            _dataSourceRepository.UpdateDataSource(request.DataSource);
            _unitOfWork.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
