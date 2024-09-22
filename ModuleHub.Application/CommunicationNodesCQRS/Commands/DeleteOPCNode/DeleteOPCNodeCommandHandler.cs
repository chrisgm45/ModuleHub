#region   USINGS

using ModuleHub.Application.Abstract;
using ModuleHub.Application.DataSources.Commands.DeleteDataSource;
using ModuleHub.Contracts.Interfaces;
using ModuleHub.Contracts;
using ModuleHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace ModuleHub.Application.CommunicationNodesCQRS.Commands.DeleteModbusNode
{
    public class DeleteOPCNodeCommandHandler
        : ICommandHandler<DeleteOPCNodeCommand>
    {
        private readonly ICommunicationNodeRepository _communicationNodeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteOPCNodeCommandHandler(
            ICommunicationNodeRepository communicationNodeRepository,
            IUnitOfWork unitOfWork)
        {
            _communicationNodeRepository = communicationNodeRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(DeleteOPCNodeCommand request, CancellationToken cancellationToken)
        {
            var opcNodeToDelete = _communicationNodeRepository.GetCommunicationNodeById<OPCNode>(request.id);
            if (opcNodeToDelete is null)
                return Task.CompletedTask;
            _communicationNodeRepository.DeleteCommunicationNode(opcNodeToDelete);
            _unitOfWork.SaveChanges();

            return Task.CompletedTask;
        }
    }
}

