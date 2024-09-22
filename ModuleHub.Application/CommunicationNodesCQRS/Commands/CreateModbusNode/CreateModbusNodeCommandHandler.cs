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
    public class CreateModbusNodeCommandHandler
         : ICommandHandler<CreateModbusNodeCommand, ModbusNode>
    {
        private readonly ICommunicationNodeRepository _communicationNodeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateModbusNodeCommandHandler(
            ICommunicationNodeRepository communicationNodeRepository,
            IUnitOfWork unitOfWork)
        {
            _communicationNodeRepository = communicationNodeRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<ModbusNode> Handle(CreateModbusNodeCommand request, CancellationToken cancellationToken)
        {
            ModbusNode result = new ModbusNode(
                Guid.NewGuid(),
                request.Name,
                request.RecordSource,
                request.CommunicationClient);

            _communicationNodeRepository.AddCommunicationNode(result);
            _unitOfWork.SaveChanges();

            return Task.FromResult(result);
        }
    }
}
