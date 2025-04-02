using Microsoft.Extensions.Logging;
using SqlSugar;
using ZhouCaiFramework.IServices;
using ZhouCaiFramework.Model.Entities;

namespace ZhouCaiFramework.Services
{
    public class TagService : ITagService
    {
        private readonly ISqlSugarClient _db;
        private readonly ILogger<TagService> _logger;

        public TagService(ISqlSugarClient db, ILogger<TagService> logger)
        {
            _db = db;
            _logger = logger;
        }

        public async Task<Tag> Create(Tag tag)
        {
            try
            {
                // 检查标签名是否已存在
                if (await _db.Queryable<Tag>()
                    .AnyAsync(x => x.Name == tag.Name))
                {
                    throw new Exception("标签名称已存在");
                }

                tag.Status = 1; // 默认启用
                tag.IsHidden = false; // 默认显示

                return await _db.Insertable(tag).ExecuteReturnEntityAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "创建标签失败");
                throw;
            }
        }

        public async Task<bool> Update(Tag tag)
        {
            return await _db.Updateable(tag)
                .IgnoreColumns(x => new { x.Status, x.IsHidden })
                .ExecuteCommandHasChangeAsync();
        }

        public async Task<bool> Delete(int tagId, bool confirm = false)
        {
            if (!confirm)
            {
                throw new Exception("请确认删除操作");
            }
            return await _db.Deleteable<Tag>()
                .Where(x => x.Id == tagId)
                .ExecuteCommandHasChangeAsync();
        }

        public async Task<bool> Disable(int tagId)
        {
            return await _db.Updateable<Tag>()
                .SetColumns(x => x.Status == 0)
                .Where(x => x.Id == tagId)
                .ExecuteCommandHasChangeAsync();
        }

        public async Task<bool> ToggleVisibility(int tagId, bool isHidden)
        {
            return await _db.Updateable<Tag>()
                .SetColumns(x => x.IsHidden == isHidden)
                .Where(x => x.Id == tagId)
                .ExecuteCommandHasChangeAsync();
        }

        public async Task<Tag> GetById(int tagId)
        {
            return await _db.Queryable<Tag>()
                .Where(x => x.Id == tagId)
                .FirstAsync();
        }

        public async Task<IEnumerable<Tag>> GetAll()
        {
            return await _db.Queryable<Tag>()
                .OrderBy(x => x.Name)
                .ToListAsync();
        }

        public async Task<IEnumerable<Tag>> GetVisibleTags()
        {
            return await _db.Queryable<Tag>()
                .Where(x => x.Status == 1 && !x.IsHidden)
                .OrderBy(x => x.Name)
                .ToListAsync();
        }
    }
}