#region    USINGS

using ModuleHub.Application.Abstract;
using ModuleHub.Contracts.Interfaces;
using ModuleHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion


namespace ModuleHub.Application.DataSources.Queries.GetDataSourceById
{
    public class GetDataSourceByIdQueryHandler
    : IQueryHandler<GetDataSourceByIdQuery, DataSource?>
    {
        private readonly IDataSourceRepository _dataSourceRepository;

        public GetDataSourceByIdQueryHandler(
            IDataSourceRepository dataSourceRepository)
        {
            _dataSourceRepository = dataSourceRepository;
        }

        public Task<DataSource?> Handle(GetDataSourceByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_dataSourceRepository.GetDataSourceById(request.Id));
        }
    }


}
