using MFF.DTO.Entities.SmartLab;
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
    public interface IBanCanMiaService
    {        Task<IEnumerable<BanCanMiaModel>> GetAllAsync();
        Task<BanCanMiaModel> GetByIdAsync(int id);
        Task<IPagination<BanCanMiaModel>> GetPagingAsync(
            int index,
            int size ,string keyword,
            string orderCol,
            string orderType
           );
        Task<IPagination<BanCanMiaModel>> GetPagingAsync(           
            int index,
            int size, int? categoryId= null);
        Task<BanCanMiaDetailModel> GetOneAsync(Expression<Func<BanCanMia, bool>> predicate = null
            , Func<IQueryable<BanCanMia>, IIncludableQueryable<BanCanMia, object>> include = null);     
        Task UpdateAsync(int id, BanCanMiaModel model);
        Task DeleteAsync(int id);
    }
}