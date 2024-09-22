using ModuleHub.Application.Abstract;
using ModuleHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleHub.Application.CommunicationClientsCQRS.Commands.CreateCommunicationClient
{
    public record CreateCommunicationClientCommand(

    string AddressIp,
    DataSource DataSource) : ICommand<CommunicationClient>;
}
