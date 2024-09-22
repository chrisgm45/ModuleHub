#region   USINGS

using ModuleHub.Application.Abstract;
using ModuleHub.Application.DataSources.Queries.GetDataSourceById;
using ModuleHub.Contracts.Interfaces;
using ModuleHub.DataAccess.Repositories.Common;
using ModuleHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


#endregion

namespace ModuleHub.Application.CommunicationClients.Queries.GetCommunicationClientById
{
    public class GetCommunicationClientByIdQueryHandler
         : IQueryHandler<GetCommunicationClientByIdQuery, CommunicationClient?>
    {
        private readonly ICommunicationClientRepository _communicationClientRepository;

        public GetCommunicationClientByIdQueryHandler(
            ICommunicationClientRepository communicationClientRepository)
        {
            _communicationClientRepository = communicationClientRepository;
        }

        public Task<CommunicationClient?> Handle(GetCommunicationClientByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_communicationClientRepository.GetCommunicationClientById(request.Id));
        }
    }
}
