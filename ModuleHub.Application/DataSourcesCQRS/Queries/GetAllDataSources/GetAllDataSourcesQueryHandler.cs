#region   USINGS

using ModuleHub.Application.Abstract;
using ModuleHub.Contracts.Interfaces;
using ModuleHub.DataAccess.Repositories.Common;
using ModuleHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion


namespace ModuleHub.Application.DataSources.Queries.GetAllDataSources
{
    public class GetAllDataSourcesQueryHandler
         : IQueryHandler<GetAllDataSourcesQuery, IEnumerable<DataSource>>
    {
        private readonly IDataSourceRepository _dataSourceRepository;

        public GetAllDataSourcesQueryHandler(
            IDataSourceRepository dataSourceRepository)
        {
            _dataSourceRepository = dataSourceRepository;
        }

        public Task<IEnumerable<DataSource>> Handle(GetAllDataSourcesQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_dataSourceRepository.GetAllDataSources());
        }
    }
}
