#region   USINGS

using ModuleHub.Application.Abstract;
using ModuleHub.Application.DataSources.Queries.GetDataSourceById;
using ModuleHub.Contracts.Interfaces;
using ModuleHub.DataAccess.Repositories.Common;
using ModuleHub.Domain.Entities;
using ModuleHub.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace ModuleHub.Application.CommunicationNodes.Queries.GetModbusNodeById
{
    public class GetOPCNodeByIdQueryHandler
     : IQueryHandler<GetOPCNodeByIdQuery, OPCNode?>
    {
        private readonly ICommunicationNodeRepository _communicationNodeRepository;

        public GetOPCNodeByIdQueryHandler(
            ICommunicationNodeRepository communicationNodeRepository)
        {
            _communicationNodeRepository = communicationNodeRepository;
        }

        public Task<OPCNode?> Handle(GetOPCNodeByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_communicationNodeRepository.GetCommunicationNodeById<OPCNode>(request.Id));
        }
    }
}

