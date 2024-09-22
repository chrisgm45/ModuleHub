#region    USINGS

using ModuleHub.Application.Abstract;
using ModuleHub.Application.DataSources.Queries.GetAllDataSources;
using ModuleHub.Contracts.Interfaces;
using ModuleHub.DataAccess.Repositories.Common;
using ModuleHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace ModuleHub.Application.CommunicationClients.Queries.GetAllCommunicationClients
{
    public class GetAllCommunicationClientsQueryHandler
       : IQueryHandler<GetAllCommunicationClientsQuery, IEnumerable<CommunicationClient>>
    {
        private readonly ICommunicationClientRepository _communicationClientRepository;

        public GetAllCommunicationClientsQueryHandler(
            ICommunicationClientRepository communicationClientRepository)
        {
            _communicationClientRepository = communicationClientRepository;
        }

        public Task<IEnumerable<CommunicationClient>> Handle(GetAllCommunicationClientsQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_communicationClientRepository.GetAllCommunicationClients());
        }
    }
}
