using AutoMapper;
using MFF.Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Security.Claims;

namespace MFF.Infrastructure
{
    public class Service : IService
    {
        protected readonly IUnitOfWork unitOfWork;
        protected readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        protected readonly IRedisCacheService redisCache;
        public Service(IUnitOfWork unitOfWork
            , IMapper mapper
            , IRedisCacheService redisCache
            , IHttpContextAccessor httpContextAccessor)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.redisCache = redisCache;
            this.httpContextAccessor = httpContextAccessor;
        }

        protected string LogedInUserId => httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
    }
}
