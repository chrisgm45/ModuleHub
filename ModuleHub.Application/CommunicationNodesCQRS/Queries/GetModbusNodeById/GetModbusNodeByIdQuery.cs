#region    USINGS

using ModuleHub.Application.Abstract;
using ModuleHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace ModuleHub.Application.DataSources.Queries.GetDataSourceById
{


    public record GetModbusNodeByIdQuery(Guid Id) : IQuery<ModbusNode>;


}