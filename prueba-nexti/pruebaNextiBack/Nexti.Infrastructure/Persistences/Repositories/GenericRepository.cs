using Nexti.Infrastructure.Commons.Bases;
using Nexti.Infrastructure.Helpers;
using Nexti.Infrastructure.Persistences.Interfaces;
using System.Linq.Dynamic.Core;

namespace Nexti.Infrastructure.Persistences.Repositories
{
    internal class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected IQueryable<TDTO> Ordering<TDTO>(BasePaginationRequest request, IQueryable<TDTO> queryable, bool pagination = false) where TDTO : class
        {
            IQueryable<TDTO> queryDto = request.Order == "desc" ? queryable.OrderBy($"{request.Sort} desending") : queryable.OrderBy($"{request.Sort} ascending");

            if (pagination) queryDto = queryDto.Paginate(request);
            return queryDto;
        }
    }
}
