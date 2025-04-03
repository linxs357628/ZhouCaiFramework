using System.Collections.Generic;
using System.Threading.Tasks;
using ZhouCaiFramework.Common;
using ZhouCaiFramework.Model.Dtos;

namespace ZhouCaiFramework.IServices
{
    /// <summary>
    /// 材料锁库服务接口
    /// 定义材料锁库相关的业务操作
    /// </summary>
    public interface IMaterialLockService
    {
        /// <summary>
        /// 获取材料锁库记录分页列表
        /// </summary>
        /// <param name="query">查询条件</param>
        /// <returns>分页的锁库记录列表</returns>
        Task<PaginatedList<MaterialLockDto>> GetMaterialLocksAsync(MaterialLockQueryDto query);

        /// <summary>
        /// 获取指定锁库记录的材料明细
        /// </summary>
        /// <param name="lockId">锁库记录ID</param>
        /// <returns>材料明细列表</returns>
        Task<List<MaterialDetailDto>> GetMaterialDetailsAsync(int lockId);

        /// <summary>
        /// 切换锁库状态
        /// </summary>
        /// <param name="lockId">锁库记录ID</param>
        /// <returns>是否切换成功</returns>
        Task<bool> ToggleLockStatusAsync(int lockId);
    }
}
