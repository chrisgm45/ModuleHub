#region   USINGS

using ModuleHub.Application.Abstract;
using ModuleHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

#endregion


namespace ModuleHub.Application.CommunicationNodes.Commands.CreateModbusNode
{
    public record CreateModbusNodeCommand(
        
        string Name,
        int RecordSource,
        CommunicationClient CommunicationClient) : ICommand<ModbusNode>;





}
