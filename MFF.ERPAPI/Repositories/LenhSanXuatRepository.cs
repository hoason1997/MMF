using MFF.DTO.Entities.SmartLab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MFF.ERPAPI.Repositories
{
    public interface LenhSanXuatRepository
    {
        void Save(LenhSanXuatImport Student);
        Task<int> AddAsync(IEnumerable<LenhSanXuatImport> items);
        Task<int> UpdateAsync(IEnumerable<LenhSanXuatImport> items);

    }
}
