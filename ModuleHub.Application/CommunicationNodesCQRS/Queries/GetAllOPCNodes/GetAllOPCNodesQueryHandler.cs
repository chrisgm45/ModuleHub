#region   USINGS 

using ModuleHub.Application.Abstract;
using ModuleHub.Application.CommunicationNodes.Queries.GetAllOPCNodes;
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
    public class GetAllOPCNodesQueryHandler
       : IQueryHandler<GetAllOPCNodesQuery, IEnumerable<OPCNode>>
    {
        private readonly ICommunicationNodeRepository _communicationNodeRepository;

        public GetAllOPCNodesQueryHandler(
            ICommunicationNodeRepository communicationNodeRepository)
        {
            _communicationNodeRepository = communicationNodeRepository;
        }

        public Task<IEnumerable<OPCNode>> Handle(GetAllOPCNodesQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_communicationNodeRepository.GetAllCommunicationNodes<OPCNode>());
        }
    }
}