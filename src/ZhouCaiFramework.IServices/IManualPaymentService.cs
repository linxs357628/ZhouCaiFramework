using ZhouCaiFramework.Model.Entities;

namespace ZhouCaiFramework.IServices
{
    /// <summary>
    /// 人工记账服务接口
    /// </summary>
    public interface IManualPaymentService
    {
        /// <summary>
        /// 创建人工记账记录
        /// </summary>
        /// <param name="record">记账记录实体</param>
        /// <returns>创建后的记录</returns>
        Task<ManualPaymentRecord> CreateAsync(ManualPaymentRecord record);

        /// <summary>
        /// 更新人工记账记录
        /// </summary>
        /// <param name="record">记账记录实体</param>
        /// <returns>更新后的记录</returns>
        Task<ManualPaymentRecord> UpdateAsync(ManualPaymentRecord record);

        /// <summary>
        /// 删除人工记账记录
        /// </summary>
        /// <param name="id">记录ID</param>
        /// <returns>是否删除成功</returns>
        Task<bool> DeleteAsync(int id);

        /// <summary>
        /// 根据ID获取记账记录
        /// </summary>
        /// <param name="id">记录ID</param>
        /// <returns>记账记录实体</returns>
        Task<ManualPaymentRecord> GetByIdAsync(int id);

        /// <summary>
        /// 获取项目关联的所有记账记录
        /// </summary>
        /// <param name="projectId">项目ID</param>
        /// <returns>记账记录列表</returns>
        Task<IEnumerable<ManualPaymentRecord>> GetByProjectAsync(int projectId);
    }
}