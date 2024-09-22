using ModuleHub.Application.Abstract;
#region     USINGS

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

namespace ModuleHub.Application.CommunicationClientsCQRS.Commands.DeleteCommunicationClient
{
    public class DeleteCommunicationClientCommandHandler
        : ICommandHandler<DeleteCommunicationClientCommand>
    {
        private readonly ICommunicationClientRepository _communicationClientRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCommunicationClientCommandHandler(
            ICommunicationClientRepository communicationClientRepository,
            IUnitOfWork unitOfWork)
        {
            _communicationClientRepository = communicationClientRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(DeleteCommunicationClientCommand request, CancellationToken cancellationToken)
        {
            var communicationClientToDelete = _communicationClientRepository.GetCommunicationClientById(request.id);
            if (communicationClientToDelete is null)
                return Task.CompletedTask;
            _communicationClientRepository.DeleteCommunicationClient(communicationClientToDelete);
            _unitOfWork.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
