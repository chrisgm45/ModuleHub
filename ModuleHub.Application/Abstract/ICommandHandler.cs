#region   USINGS

using MediatR;
using ModuleHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace ModuleHub.Application.Abstract
{
    public interface ICommandHandler<TCommand>
        : IRequestHandler<TCommand>
        where TCommand : ICommand
    {

    }

    public interface ICommandHandler<TCommand, TResponse>
        : IRequestHandler<TCommand, TResponse>
        where TCommand : ICommand<TResponse>
    {

    }
    
}
