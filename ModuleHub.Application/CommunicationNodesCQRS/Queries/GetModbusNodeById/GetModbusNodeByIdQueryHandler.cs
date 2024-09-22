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
    public class GetModbusNodeByIdQueryHandler
     : IQueryHandler<GetModbusNodeByIdQuery, ModbusNode?>
    {
        private readonly ICommunicationNodeRepository _communicationNodeRepository;

        public GetModbusNodeByIdQueryHandler(
            ICommunicationNodeRepository communicationNodeRepository)
        {
            _communicationNodeRepository = communicationNodeRepository;
        }

        public Task<ModbusNode?> Handle(GetModbusNodeByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_communicationNodeRepository.GetCommunicationNodeById<ModbusNode>(request.Id));
        }
    }
}
