using System.Collections.Generic;
using System.Threading.Tasks;
using ZhouCaiFramework.Common;
using ZhouCaiFramework.Model.Dtos;

namespace ZhouCaiFramework.IServices
{
    public interface IMaterialLockService
    {
        Task<PaginatedList<MaterialLockDto>> GetMaterialLocksAsync(MaterialLockQueryDto query);
        Task<List<MaterialDetailDto>> GetMaterialDetailsAsync(int lockId);
        Task<bool> ToggleLockStatusAsync(int lockId);
    }
}
