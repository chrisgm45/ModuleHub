#region   USINGS

using ModuleHub.Application.Abstract;
using ModuleHub.Application.CommunicationNodes.Commands.CreateModbusNode;
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

namespace ModuleHub.Application.CommunicationNodesCQRS.Commands.CreateModbusNode
{
    public class CreateOPCNodeCommandHandler
         : ICommandHandler<CreateOPCNodeCommand, OPCNode>
    {
        private readonly ICommunicationNodeRepository _communicationNodeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateOPCNodeCommandHandler(
            ICommunicationNodeRepository communicationNodeRepository,
            IUnitOfWork unitOfWork)
        {
            _communicationNodeRepository = communicationNodeRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<OPCNode> Handle(CreateOPCNodeCommand request, CancellationToken cancellationToken)
        {
            OPCNode result = new OPCNode(
                Guid.NewGuid(),
                request.AddressLabel,
                request.CommunicationClient);

            _communicationNodeRepository.AddCommunicationNode(result);
            _unitOfWork.SaveChanges();

            return Task.FromResult(result);
        }
    }
}