using MFF.ERPAPI.Database;
using MFF.ERPAPI.Entities;
using MFF.ERPAPI.Factories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MFF.ERPAPI.Services
{
    public class LSXService
    {
        private readonly IUnitOfWork _unitOfWork;
     //   private ILogger<ValuesController> _logger;
        public LSXService(IUnitOfWork<BHSTADBContext> unitOfWork)
        {
            _lenhsxrepo = unitOfWork.Repository<LenhSanXuatERP>();
            _unitOfWork = unitOfWork;
        }
        public async Task<int> AddAsync(IEnumerable<LenhSanXuatERP> items)
        {
            try
            {
              //  await lenhSXRepo.AddAsync(items);
              //  return await _unitOfWork.SaveChangesAsync();
            }
            catch (System.Exception ex)
            {
                Serilog.Log.Error(ex.StackTrace);
                return 0;
            }
        }
        public async Task<int> UpdateAsync(IEnumerable<LenhSanXuatERP> items)
        {
          //  lenhSXRepo.Update(items);
         //   return await _unitOfWork.SaveChangesAsync();
        }
    }
    public class TTTieuHaoService 
    {

        //private readonly IMapper mapper;
        //private readonly IBaseRepository<ThongTinTieuHao> lenhSXRepo;
        //private readonly IUnitOfWork _unitOfWork;
        //public TTTieuHaoService(IUnitOfWork unitOfWork, IMapper mapper)
        //{
        //    this.lenhSXRepo = unitOfWork.Repository<ThongTinTieuHao>();
        //    _unitOfWork = unitOfWork;
        //}
        //public async Task<int> AddAsync(IEnumerable<ThongTinTieuHao> items)
        //{
        //    try
        //    {
        //        await lenhSXRepo.AddAsync(items);
        //        return await _unitOfWork.SaveChangesAsync();
        //    }
        //    catch (System.Exception ex)
        //    {

        //        Serilog.Log.Error(ex.StackTrace);
        //        return 0;
        //    }
        //}
        //public async Task<int> UpdateAsync(IEnumerable<ThongTinTieuHao> items)
        //{
        //    lenhSXRepo.Update(items);
        //    return await _unitOfWork.SaveChangesAsync();
        //}
    }
}
