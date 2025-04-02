using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ZhouCaiFramework.IServices;
using ZhouCaiFramework.Model.Dtos;
using ZhouCaiFramework.Model.Entities;

namespace ZhouCaiFramework.Web.Controllers.Admin
{
    [ApiController]
    [Route("api/admin/[controller]")]
    [Authorize(Roles = "admin")]
    public class EnterpriseController : AdminBaseController
    {
        private readonly IEnterpriseService _enterpriseService;
        private readonly ITagService _tagService;

        public EnterpriseController(
            IEnterpriseService enterpriseService,
            ITagService tagService,
            ILogger<EnterpriseController> logger) : base(null, logger)
        {
            _enterpriseService = enterpriseService;
            _tagService = tagService;
        }

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
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] EnterpriseUpdateDto dto)
        {
            var enterprise = await _enterpriseService.GetById(id);
            if (enterprise == null)
            {
                return NotFound();
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
            return success ? Ok() : BadRequest();
        }

        [HttpPut("{id}/disable")]
        public async Task<IActionResult> Disable(int id)
        {
            var success = await _enterpriseService.Disable(id);
            return success ? Ok() : BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _enterpriseService.Delete(id);
            return success ? Ok() : BadRequest();
        }

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

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var enterprises = await _enterpriseService.GetAll();
            return Ok(enterprises);
        }

        [HttpGet("validate-name")]
        public async Task<IActionResult> ValidateEnterpriseName([FromQuery] string name)
        {
            var isValid = await _enterpriseService.ValidateEnterpriseName(name);
            return Ok(new { IsValid = isValid });
        }

        // 共享仓管理相关API
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
            return Ok(result);
        }

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
            return success ? Ok() : BadRequest();
        }

        [HttpDelete("{enterpriseId}/warehouses/{warehouseId}")]
        public async Task<IActionResult> RemoveWarehouse(int enterpriseId, int warehouseId)
        {
            var success = await _enterpriseService.RemoveWarehouse(warehouseId);
            return success ? Ok() : BadRequest();
        }

        [HttpGet("{enterpriseId}/warehouses")]
        public async Task<IActionResult> GetWarehouses(int enterpriseId)
        {
            var enterprise = await _enterpriseService.GetById(enterpriseId);
            if (enterprise == null)
            {
                return NotFound();
            }

            return Ok(enterprise.Warehouses);
        }
    }
}