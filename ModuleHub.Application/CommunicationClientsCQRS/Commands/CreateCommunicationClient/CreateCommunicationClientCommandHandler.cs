#region   USINGS

using ModuleHub.Application.Abstract;
using ModuleHub.Contracts;
using ModuleHub.Contracts.Interfaces;
using ModuleHub.DataAccess.Contexts;
using ModuleHub.DataAccess.Repositories.Common;
using ModuleHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace ModuleHub.Application.CommunicationClientsCQRS.Commands.CreateCommunicationClient
{
    public class CreateCommunicationClientCommandHandler
       : ICommandHandler<CreateCommunicationClientCommand, CommunicationClient>
    {
        private readonly ICommunicationClientRepository _communicationClientRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCommunicationClientCommandHandler(
            ICommunicationClientRepository communicationClientRepository,
            IUnitOfWork unitOfWork)
        {
            _communicationClientRepository = communicationClientRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<CommunicationClient> Handle(CreateCommunicationClientCommand request, CancellationToken cancellationToken)
        {
            CommunicationClient result = new CommunicationClient(
                Guid.NewGuid(),
                request.AddressIp,
                request.DataSource);

            _communicationClientRepository.AddCommunicationClient(result);
            _unitOfWork.SaveChanges();
            

            return Task.FromResult(result);
        }
    }
}
