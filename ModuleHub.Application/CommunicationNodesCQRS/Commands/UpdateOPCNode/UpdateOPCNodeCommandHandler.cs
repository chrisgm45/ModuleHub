#region   USINGS

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

namespace ModuleHub.Application.CommunicationNodesCQRS.Commands.UpdateModbusNode
{
    public class UpdateOPCNodeCommandHandler
        : ICommandHandler<UpdateOPCNodeCommand>
    {
        private readonly ICommunicationNodeRepository _communicationNodeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateOPCNodeCommandHandler(
            ICommunicationNodeRepository communicationNodeRepository,
            IUnitOfWork unitOfWork)
        {
            _communicationNodeRepository = communicationNodeRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(UpdateOPCNodeCommand request, CancellationToken cancellationToken)
        {
            _communicationNodeRepository.UpdateCommunicationNode(request.OPCNode);
            _unitOfWork.SaveChanges();
            return Task.CompletedTask;
        }
    }
}

