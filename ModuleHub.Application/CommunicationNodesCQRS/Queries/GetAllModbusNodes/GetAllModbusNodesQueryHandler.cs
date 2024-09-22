#region   USINGS 

using ModuleHub.Application.Abstract;
using ModuleHub.Contracts.Interfaces;
using ModuleHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace ModuleHub.Application.CommunicationNodes.Queries.GetAllModbusNodes
{
    public class GetAllModbusNodesQueryHandler
       : IQueryHandler<GetAllModbusNodesQuery, IEnumerable<ModbusNode>>
    {
        private readonly ICommunicationNodeRepository _communicationNodeRepository;

        public GetAllModbusNodesQueryHandler(
            ICommunicationNodeRepository communicationNodeRepository)
        {
            _communicationNodeRepository = communicationNodeRepository;
        }

        public Task<IEnumerable<ModbusNode>> Handle(GetAllModbusNodesQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_communicationNodeRepository.GetAllCommunicationNodes<ModbusNode>());
        }
    }
}
