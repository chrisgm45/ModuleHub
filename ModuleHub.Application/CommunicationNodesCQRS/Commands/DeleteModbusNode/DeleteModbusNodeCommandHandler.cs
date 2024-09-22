using ModuleHub.Application.Abstract;
using ModuleHub.Application.DataSources.Commands.DeleteDataSource;
using ModuleHub.Contracts;
using ModuleHub.Contracts.Interfaces;
using ModuleHub.DataAccess.Repositories.Common;
#region   USINGS

using ModuleHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace ModuleHub.Application.CommunicationNodesCQRS.Commands.DeleteModbusNode
{
    public class DeleteModbusNodeCommandHandler
        : ICommandHandler<DeleteModbusNodeCommand>
    {
        private readonly ICommunicationNodeRepository _communicationNodeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteModbusNodeCommandHandler(
            ICommunicationNodeRepository communicationNodeRepository,
            IUnitOfWork unitOfWork)
        {
            _communicationNodeRepository = communicationNodeRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(DeleteModbusNodeCommand request, CancellationToken cancellationToken)
        {
            var modbusNodeToDelete = _communicationNodeRepository.GetCommunicationNodeById<ModbusNode>(request.id);
            if (modbusNodeToDelete is null)
                return Task.CompletedTask;
            _communicationNodeRepository.DeleteCommunicationNode(modbusNodeToDelete);
            _unitOfWork.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
