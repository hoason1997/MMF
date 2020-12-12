using MFF.DTO.Entities.NHCH;
using MFF.Infrastructure.Models;
using MFF.Infrastructure.Paging;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MFF.Infrastructure.Services
{
    public interface ICauHoiService
    {        Task<IEnumerable<CauHoiModel>> GetAllAsync();
        Task<CauHoiModel> GetByIdAsync(string id);
        Task<IPagination<CauHoiModel>> GetPagingAsync(
            int index,
            int size ,string keyword,
            string orderCol,
            string orderType
           );
        Task<IPagination<CauHoiModel>> GetPagingAsync(           
            int index,
            int size, int? categoryId= null);
        Task<CauHoiDetailModel> GetOneAsync(Expression<Func<CauHoi, bool>> predicate = null
            , Func<IQueryable<CauHoi>, IIncludableQueryable<CauHoi, object>> include = null);     
        Task UpdateAsync(string id, CauHoiModel model);
        Task DeleteAsync(string id);
    }
}