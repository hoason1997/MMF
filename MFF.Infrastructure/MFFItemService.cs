using MFF.DTO.BaseEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MFF.Infrastructure
{
    public class MFFItemService : IMFFItemService
    {
        //private readonly MFFDbContext _dbContext;
        //private readonly ILogger<MFFItemService> _logger;

        //public MFFItemService(MFFDbContext dbContext)
        //{
        //    this._dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        //}

        //public MFFItemService(MFFDbContext dbContext, ILogger<MFFItemService> logger)
        //{
        //    this._dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        //    this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
        //}

        //public async Task<MFFItem> GetAsync(Guid id)
        //{
        //    return await _dbContext.MFFItem.FindAsync(id);
        //}

        //public async Task<IEnumerable<MFFItem>> GetItemsAsync()
        //{
        //    return await _dbContext.MFFItem.AsNoTracking().Select(s => s).ToListAsync();
        //}

        //public async Task AddItemAsync(MFFItem item)
        //{
        //    await _dbContext.MFFItem.AddAsync(item);
        //    await _dbContext.SaveChangesAsync();
        //    _logger?.LogInformation($"{item.Name} created.");
        //}

        //public async Task DeleteItemAsync(Guid id)
        //{
        //    var item = await _dbContext.MFFItem.FindAsync(id);
        //    _dbContext.MFFItem.Remove(item);
        //    await _dbContext.SaveChangesAsync();
        //    _logger?.LogInformation($"Item {item.Name} deleted.");
        //}

        //public async Task UpdateItemAsync(MFFItem item)
        //{
        //    var itemInDb = await _dbContext.MFFItem.FindAsync(item.Id);
        //    itemInDb.Name = item.Name;
        //    await _dbContext.SaveChangesAsync();
        //    _logger?.LogInformation($"{item.Name} updated.");
        //}
    }
}