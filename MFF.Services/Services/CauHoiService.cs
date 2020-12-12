using AutoMapper;
using AutoMapper.QueryableExtensions;
using MFF.DTO.Constants;
using MFF.DTO.Entities.NHCH;
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
    public class CauHoiService : Service, ICauHoiService
    {
        private readonly IRepository<CauHoi> postRepo;
        private readonly IMemoryCache _cache;
        public CauHoiService(IUnitOfWork unitOfWork, IMapper mapper, IRedisCacheService redisCache, IHttpContextAccessor httpContextAccessor, IMemoryCache cache)
            : base(unitOfWork, mapper, redisCache, httpContextAccessor)
        {
            postRepo = unitOfWork.Repository<CauHoi>();
            _cache = cache;
        }
        public async Task<IEnumerable<CauHoiModel>> GetAllAsync()
        {
            var posts = await postRepo
                    .Query()
                    .ProjectTo<CauHoiModel>(mapper.ConfigurationProvider)
                    .ToListAsync();
            return posts;
        }

        public async Task<CauHoiModel> GetByIdAsync(string id)
        {
            var data = await postRepo
                .Query(x => x.Id == id)
                .ProjectTo<CauHoiModel>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
            return data;
        }

        public async Task<IPagination<CauHoiModel>> GetPagingAsync(int index, int size, int? categoryId = null)
        {
            var predicate = new List<Expression<Func<CauHoi, bool>>> { x => true };
            //predicate.Add(x => x.CategoryId.Contains(string.Format(Constant.QueryFormat, categoryId)));
            var query = postRepo.Query(predicate.Aggregate((a, b) => a.And(b)));//, orderBy: x => x.OrderByDescending(z => z.CreatedTime));
            var data = await query.ToPaginateAsync<CauHoi, CauHoiModel>(mapper, index, size, 0);
            return data;
        }
        public async Task<IPagination<CauHoiModel>> GetPagingAsync(int index, int size,string keyword = null, string orderCol = null, string orderType = null)
        {
            var predicate = new List<Expression<Func<CauHoi, bool>>> { x => true };


            if (!string.IsNullOrEmpty(keyword))
            {
                keyword = keyword.Trim();
                var keywords = keyword.Split(" ").ToList().Where(x => !string.IsNullOrEmpty(x));
                if (keywords.Count() > 0)
                {
                    foreach (var i in keywords)
                    {
                        predicate.Add(x =>
                          x.TenCauHoi.Contains(i)
                       || x.TenCauHoiPhu.Contains(i));
                    }
                }
            }

            Func<IQueryable<CauHoi>, IOrderedQueryable<CauHoi>> orderBy = null;
            if (!string.IsNullOrEmpty(orderCol))
            {
                if (!string.IsNullOrEmpty(orderType))
                    orderBy = OrderByHelper.GetOrderBy<CauHoi>(orderCol, orderType);
            }

            var query = postRepo.Query(predicate.Aggregate((a, b) => a.And(b)), orderBy);

            var data = await query.ToPaginateAsync<CauHoi, CauHoiModel>(mapper, index, size, 0);
            return data;
        }

        public async Task<CauHoiDetailModel> GetOneAsync(Expression<Func<CauHoi, bool>> predicate = null
            , Func<IQueryable<CauHoi>, IIncludableQueryable<CauHoi, object>> include = null)
        {
            var query = postRepo.Query(predicate, null, include);
            return await query.ProjectTo<CauHoiDetailModel>(mapper.ConfigurationProvider).FirstOrDefaultAsync();
        }

        public async Task<string> AddAsync(CauHoiModel model)
        {

            if (model == null) return string.Empty;

            var post = mapper.Map<CauHoi>(model);

            post.CreatedBy = post.UpdatedBy = LogedInUserId;

            await postRepo.AddAsync(post);
            var saveResult = await unitOfWork.SaveChangesAsync();

            if (saveResult > 0) return post.Id;
            return string.Empty;
        }

        public async Task UpdateAsync(string id, CauHoiModel model)
        {
            if (model == null)
                throw new ArgumentException();
            var post = await postRepo.Query().FirstOrDefaultAsync(x => x.Id == id);

            if (post == null)
                throw new MethodAccessException(MessageConstant.POST_NOT_FOUND);

            var postUpdate = mapper.Map(model, post);

            postUpdate.UpdatedTime = DateTime.UtcNow;
            postUpdate.UpdatedBy = LogedInUserId;
            postUpdate.Id = id;

            postRepo.Update(postUpdate);
            var saveResult = await unitOfWork.SaveChangesAsync();

            if (saveResult <= 0)
            {
                throw new Exception(MessageConstant.POST_NOT_UPDATE_FAILED);
            }
        }

        public async Task DeleteAsync(string id)
        {
            var post = await postRepo.Query(x => x.Id == id).FirstOrDefaultAsync();

            if (post != null)
            {
                postRepo.Delete(post);
                var result = await unitOfWork.SaveChangesAsync();
                if (result <= 0)
                {
                    throw new Exception(MessageConstant.POST_NOT_DELETE_FAILED);
                }
            }
        }
    }

}
