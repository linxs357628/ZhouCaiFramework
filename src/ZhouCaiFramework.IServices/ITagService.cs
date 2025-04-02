using ZhouCaiFramework.Model.Entities;

namespace ZhouCaiFramework.IServices
{
    public interface ITagService
    {
        Task<Tag> Create(Tag tag);

        Task<bool> Update(Tag tag);

        Task<bool> Delete(int tagId, bool confirm = false);

        Task<bool> Disable(int tagId);

        Task<bool> ToggleVisibility(int tagId, bool isHidden);

        Task<Tag> GetById(int tagId);

        Task<IEnumerable<Tag>> GetAll();

        Task<IEnumerable<Tag>> GetVisibleTags();
    }
}