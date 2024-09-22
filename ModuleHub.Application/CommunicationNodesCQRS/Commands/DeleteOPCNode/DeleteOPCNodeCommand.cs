﻿#region   USINGS

using ModuleHub.Application.Abstract;
using ModuleHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion


namespace ModuleHub.Application.DataSources.Commands.DeleteDataSource
{
    public record DeleteOPCNodeCommand(Guid id) : ICommand;

}
