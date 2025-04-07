using Microsoft.AspNetCore.Mvc;
using ZhouCaiFramework.IServices;
using ZhouCaiFramework.Model.Dtos;
using ZhouCaiFramework.Model.Entities;

namespace ZhouCaiFramework.Web.Controllers.Admin
{
    /// <summary>
    ///
    /// </summary>

    public class MerchantLevelController : AdminBaseController
    {
        private readonly IMerchantLevelService _merchantLevelService;

        public MerchantLevelController(IMerchantLevelService merchantLevelService, ILogger<MerchantLevelController> logger)
            : base(logger)
        {
            _merchantLevelService = merchantLevelService;
        }

        /// <summary>
        /// �����̻��ȼ�
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MerchantLevelCreateDto dto)
        {
            var level = new MerchantLevel
            {
                EnterpriseType = dto.EnterpriseType,
                Level = dto.Level,
                Permissions = dto.Permissions
            };

            var result = await _merchantLevelService.Create(level);
            return Success(result);
        }

        /// <summary>
        /// �����̻��ȼ�
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] MerchantLevelUpdateDto dto)
        {
            var level = await _merchantLevelService.GetById(id);
            if (level == null)
            {
                return NotFound();
            }

            level.EnterpriseType = dto.EnterpriseType;
            level.Level = dto.Level;
            level.Permissions = dto.Permissions;

            var success = await _merchantLevelService.Update(level);
            return success ? Success(success) : BadRequest<bool>();
        }

        /// <summary>
        /// ���á������̻��ȼ�
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}/disable")]
        public async Task<IActionResult> Disable(int id)
        {
            var success = await _merchantLevelService.Disable(id);
            return success ? Success(success) : BadRequest<bool>();
        }

        /// <summary>
        /// ɾ���̻��ȼ�
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _merchantLevelService.Delete(id);
            return success ? Success(success) : BadRequest<bool>();
        }

        /// <summary>
        /// ��ȡ�̻��ȼ�
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var level = await _merchantLevelService.GetById(id);
            return level != null ? Success(level) : NotFound<MerchantLevel>();
        }

        /// <summary>
        /// ��ȡ�����̻��ȼ�
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var levels = await _merchantLevelService.GetAll();
            return Success(levels);
        }

        /// <summary>
        /// ��ȡָ���̻����͵������̻��ȼ�
        /// </summary>
        /// <param name="enterpriseType"></param>
        /// <returns></returns>
        [HttpGet("by-enterprise-type/{enterpriseType}")]
        public async Task<IActionResult> GetByEnterpriseType(string enterpriseType)
        {
            var levels = await _merchantLevelService.GetByEnterpriseType(enterpriseType);
            return Success(levels);
        }
    }
}