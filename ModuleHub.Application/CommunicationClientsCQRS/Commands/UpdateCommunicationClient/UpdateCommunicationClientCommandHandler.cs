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

namespace ModuleHub.Application.CommunicationClientsCQRS.Commands.UpdateCommunicationClient
{
    public class UpdateCommunicationClientCommandHandler
        : ICommandHandler<UpdateCommunicationClientCommand>
    {
        private readonly ICommunicationClientRepository _communicationClientRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCommunicationClientCommandHandler(
            ICommunicationClientRepository communicationClientRepository,
            IUnitOfWork unitOfWork)
        {
            _communicationClientRepository = communicationClientRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(UpdateCommunicationClientCommand request, CancellationToken cancellationToken)
        {
            _communicationClientRepository.UpdateCommunicationClient(request.CommunicationClient);
            _unitOfWork.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
