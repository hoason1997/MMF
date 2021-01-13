using AutoMapper;
using AutoMapper.QueryableExtensions;
using MFF.DTO.Constants;
using MFF.DTO.Entities.SmartLab;
using MFF.DTO.Helpers;
using MFF.Infrastructure.Extensions;
using MFF.Infrastructure.Models;
using MFF.Infrastructure.Paging;
using MFF.Infrastructure.Repositories;
using MFF.Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MFF.Infrastructure.Services
{
    public class BanCanMiaService : Service<BanCanMia>, IBanCanMiaService
    {
        private readonly IBaseRepository<BanCanMia> _repoBanCanMia;

        public BanCanMiaService(IUnitOfWork unitOfWork, IMapper mapper, IRedisCacheService redisCache, IHttpContextAccessor httpContextAccessor, IMemoryCache cache)
            : base(unitOfWork, mapper, redisCache, httpContextAccessor)
        {
            _repoBanCanMia = unitOfWork.Repository<BanCanMia>();
        }
        public async Task<IEnumerable<BanCanMiaModel>> GetAllAsync()
        {
            var posts = await _repoBanCanMia
                    .Query()
                    .ProjectTo<BanCanMiaModel>(mapper.ConfigurationProvider)
                    .ToListAsync();
            return posts;
        }

        public async Task<BanCanMiaModel> GetByIdAsync(int id)
        {
            var data = await _repoBanCanMia
                .Query(x => x.Ma_BanCanMia == id)
                .ProjectTo<BanCanMiaModel>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
            return data;
        }

        public async Task<IPagination<BanCanMiaModel>> GetPagingAsync(int index, int size, int? categoryId = null)
        {
            var predicate = new List<Expression<Func<BanCanMia, bool>>> { x => true };
            //predicate.Add(x => x.CategoryId.Contains(string.Format(Constant.QueryFormat, categoryId)));
            var query = _repoBanCanMia.Query(predicate.Aggregate((a, b) => a.And(b)));//, orderBy: x => x.OrderByDescending(z => z.CreatedTime));
            var data = await query.ToPaginateAsync<BanCanMia, BanCanMiaModel>(mapper, index, size, 0);
            return data;
        }
        public async Task<IPagination<BanCanMiaModel>> GetPagingAsync(int index, int size, string keyword = null, string orderCol = null, string orderType = null)
        {
            var predicate = new List<Expression<Func<BanCanMia, bool>>> { x => true };


            if (!string.IsNullOrEmpty(keyword))
            {
                keyword = keyword.Trim();
                var keywords = keyword.Split(" ").ToList().Where(x => !string.IsNullOrEmpty(x));
                if (keywords.Count() > 0)
                {
                    foreach (var i in keywords)
                    {
                        predicate.Add(x =>
                          x.Ma_Cttv.Equals(i)
                       || x.Ma_SoCa.Equals(i));
                    }
                }
            }

            Func<IQueryable<BanCanMia>, IOrderedQueryable<BanCanMia>> orderBy = null;
            if (!string.IsNullOrEmpty(orderCol))
            {
                if (!string.IsNullOrEmpty(orderType))
                    orderBy = OrderByHelper.GetOrderBy<BanCanMia>(orderCol, orderType);
            }

            var query = _repoBanCanMia.Query(predicate.Aggregate((a, b) => a.And(b)), orderBy);

            var data = await query.ToPaginateAsync<BanCanMia, BanCanMiaModel>(mapper, index, size, 0);
            return data;
        }

        public async Task<BanCanMiaDetailModel> GetOneAsync(Expression<Func<BanCanMia, bool>> predicate = null
            , Func<IQueryable<BanCanMia>, IIncludableQueryable<BanCanMia, object>> include = null)
        {
            var query = _repoBanCanMia.Query(predicate, null, include);
            return await query.ProjectTo<BanCanMiaDetailModel>(mapper.ConfigurationProvider).FirstOrDefaultAsync();
        }

        public async Task<string> AddAsync(BanCanMiaModel model)
        {

            if (model == null) return string.Empty;

            var post = mapper.Map<BanCanMia>(model);

            post.TaoBoi = post.CapNhatBoi;// = LogedInUserId;

           await _repoBanCanMia.AddAsync(post);
            var saveResult = await unitOfWork.SaveChangesAsync();
            if (saveResult > 0) return post.Ma_BanCanMia + string.Empty;
            return string.Empty;
        }

        public async Task UpdateAsync(int id, BanCanMiaModel model)
        {
            if (model == null)
                throw new ArgumentException();
            var post = await _repoBanCanMia.Query().FirstOrDefaultAsync(x => x.Ma_BanCanMia == id);

            if (post == null)
                throw new MethodAccessException(MessageConstant.POST_NOT_FOUND);

            var postUpdate = mapper.Map(model, post);

            postUpdate.NgayCapNhat = DateTime.UtcNow;
            postUpdate.CapNhatBoi = "";// LogedInUserId;
            postUpdate.Ma_BanCanMia = id;

            _repoBanCanMia.Update(postUpdate);
            var saveResult = await unitOfWork.SaveChangesAsync();

            if (saveResult <= 0)
            {
                throw new Exception(MessageConstant.POST_NOT_UPDATE_FAILED);
            }
        }

        public async Task DeleteAsync(int id)
        {
            var post = await _repoBanCanMia.Query(x => x.Ma_BanCanMia == id).FirstOrDefaultAsync();

            if (post != null)
            {
                _repoBanCanMia.Delete(post);
                var result = await unitOfWork.SaveChangesAsync();
                if (result <= 0)
                {
                    throw new Exception(MessageConstant.POST_NOT_DELETE_FAILED);
                }
            }
        }
    }

}
