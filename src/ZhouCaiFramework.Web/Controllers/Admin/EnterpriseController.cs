using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ZhouCaiFramework.IServices;
using ZhouCaiFramework.Model.Dtos;
using ZhouCaiFramework.Model.Entities;

namespace ZhouCaiFramework.Web.Controllers.Admin
{
    /// <summary>
    /// 企业管理
    /// </summary>

    public class EnterpriseController : AdminBaseController
    {
        private readonly IEnterpriseService _enterpriseService;
        private readonly ITagService _tagService;

        public EnterpriseController(
            IEnterpriseService enterpriseService,
            ITagService tagService,
            ILogger<EnterpriseController> logger) : base(logger)
        {
            _enterpriseService = enterpriseService;
            _tagService = tagService;
        }

        /// <summary>
        /// 创建企业
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EnterpriseCreateDto dto)
        {
            var enterprise = new Enterprise
            {
                Province = dto.Province,
                City = dto.City,
                District = dto.District,
                EnterpriseType = dto.EnterpriseType,
                Name = dto.Name,
                ShortName = dto.ShortName,
                Level = dto.Level,
                ParentEnterpriseId = dto.ParentEnterpriseId,
                LegalPerson = dto.LegalPerson,
                LegalPhone = dto.LegalPhone,
                EnterprisePrefix = dto.EnterprisePrefix,
                SalesmanId = dto.SalesmanId,
                MainAccountId = dto.MainAccountId,
                Tags = JsonConvert.SerializeObject(dto.TagIds),
                Grade = dto.Grade
            };

            var result = await _enterpriseService.Create(enterprise);
            return Success(result);
        }

        /// <summary>
        /// 更新企业
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] EnterpriseUpdateDto dto)
        {
            var enterprise = await _enterpriseService.GetById(id);
            if (enterprise == null)
            {
                return NotFound<bool>();
            }

            enterprise.Province = dto.Province;
            enterprise.City = dto.City;
            enterprise.District = dto.District;
            enterprise.EnterpriseType = dto.EnterpriseType;
            enterprise.Name = dto.Name;
            enterprise.ShortName = dto.ShortName;
            enterprise.Level = dto.Level;
            enterprise.ParentEnterpriseId = dto.ParentEnterpriseId;
            enterprise.LegalPerson = dto.LegalPerson;
            enterprise.LegalPhone = dto.LegalPhone;
            enterprise.EnterprisePrefix = dto.EnterprisePrefix;
            enterprise.SalesmanId = dto.SalesmanId;
            enterprise.MainAccountId = dto.MainAccountId;
            enterprise.Tags = JsonConvert.SerializeObject(dto.TagIds);
            enterprise.Grade = dto.Grade;

            var success = await _enterpriseService.Update(enterprise);
            return success ? Success(success) : BadRequest();
        }

        /// <summary>
        /// 启用 、禁用 企业
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}/disable")]
        public async Task<IActionResult> Disable(int id)
        {
            var success = await _enterpriseService.Disable(id);
            return success ? Success(success) : BadRequest();
        }

        /// <summary>
        /// 删除企业
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _enterpriseService.Delete(id);
            return success ? Success(success) : BadRequest();
        }

        /// <summary>
        /// 获取企业详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var enterprise = await _enterpriseService.GetById(id);
            if (enterprise == null)
            {
                return NotFound();
            }

            var result = new EnterpriseDetailDto
            {
                Id = enterprise.Id,
                Province = enterprise.Province,
                City = enterprise.City,
                District = enterprise.District,
                EnterpriseType = enterprise.EnterpriseType,
                Name = enterprise.Name,
                ShortName = enterprise.ShortName,
                Level = enterprise.Level,
                ParentEnterpriseId = enterprise.ParentEnterpriseId,
                LegalPerson = enterprise.LegalPerson,
                LegalPhone = enterprise.LegalPhone,
                EnterprisePrefix = enterprise.EnterprisePrefix,
                SalesmanId = enterprise.SalesmanId,
                MainAccountId = enterprise.MainAccountId,
                TagIds = JsonConvert.DeserializeObject<List<int>>(enterprise.Tags ?? "[]"),
                Grade = enterprise.Grade,
                Status = enterprise.Status,
                CreateTime = enterprise.CreateTime,
                UpdateTime = enterprise.UpdateTime,
                Warehouses = enterprise.Warehouses
            };

            return Success(result);
        }

        /// <summary>
        /// 获取所有企业
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var enterprises = await _enterpriseService.GetAll();
            return Success(enterprises);
        }

        /// <summary>
        /// 获取所有标签
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("validate-name")]
        public async Task<IActionResult> ValidateEnterpriseName([FromQuery] string name)
        {
            var isValid = await _enterpriseService.ValidateEnterpriseName(name);
            return Success(new { IsValid = isValid });
        }

        #region 共享仓管理相关API

        /// <summary>
        /// 创建共享仓
        /// </summary>
        /// <param name="enterpriseId"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("{enterpriseId}/warehouses")]
        public async Task<IActionResult> AddWarehouse(int enterpriseId, [FromBody] WarehouseCreateDto dto)
        {
            var warehouse = new SharedWarehouse
            {
                EnterpriseId = enterpriseId,
                Name = dto.Name,
                Location = dto.Location,
                Address = dto.Address,
                MainStorage = dto.MainStorage,
                Area = dto.Area,
                OpenTime = dto.OpenTime,
                CloseTime = dto.CloseTime,
                IsShared = dto.IsShared,
                Type = dto.Type
            };

            var result = await _enterpriseService.AddWarehouse(warehouse);
            return Success(result);
        }

        /// <summary>
        /// 更新共享仓
        /// </summary>
        /// <param name="enterpriseId"></param>
        /// <param name="warehouseId"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut("{enterpriseId}/warehouses/{warehouseId}")]
        public async Task<IActionResult> UpdateWarehouse(int enterpriseId, int warehouseId, [FromBody] WarehouseUpdateDto dto)
        {
            var warehouse = new SharedWarehouse
            {
                Id = warehouseId,
                EnterpriseId = enterpriseId,
                Name = dto.Name,
                Location = dto.Location,
                Address = dto.Address,
                MainStorage = dto.MainStorage,
                Area = dto.Area,
                OpenTime = dto.OpenTime,
                CloseTime = dto.CloseTime,
                IsShared = dto.IsShared,
                Type = dto.Type
            };

            var success = await _enterpriseService.UpdateWarehouse(warehouse);
            return success ? Success(success) : BadRequest();
        }

        /// <summary>
        /// 删除共享仓
        /// </summary>
        /// <param name="enterpriseId"></param>
        /// <param name="warehouseId"></param>
        /// <returns></returns>
        [HttpDelete("{enterpriseId}/warehouses/{warehouseId}")]
        public async Task<IActionResult> RemoveWarehouse(int enterpriseId, int warehouseId)
        {
            var success = await _enterpriseService.RemoveWarehouse(warehouseId);
            return success ? Success(success) : BadRequest();
        }

        /// <summary>
        /// 获取企业共享仓
        /// </summary>
        /// <param name="enterpriseId"></param>
        /// <returns></returns>
        [HttpGet("{enterpriseId}/warehouses")]
        public async Task<IActionResult> GetWarehouses(int enterpriseId)
        {
            var enterprise = await _enterpriseService.GetById(enterpriseId);
            if (enterprise == null)
            {
                return NotFound();
            }

            return Success(enterprise.Warehouses);
        }

        #endregion 共享仓管理相关API
    }
}