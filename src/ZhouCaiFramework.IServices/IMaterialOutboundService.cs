using System.Collections.Generic;
using System.Threading.Tasks;
using ZhouCaiFramework.Model.Dtos;

namespace ZhouCaiFramework.IServices
{
    public interface IMaterialOutboundService
    {
        Task<MaterialOutboundDetailDto> GetOutboundDetailAsync(int outboundId);
        Task<List<MaterialDetailDto>> GetMaterialDetailsAsync(int outboundId);
        Task<int> CreateMaterialDetailAsync(MaterialDetailEditDto dto);
        Task<bool> UpdateMaterialDetailAsync(MaterialDetailEditDto dto);
        Task<bool> DeleteMaterialDetailAsync(int detailId);
    }
}
