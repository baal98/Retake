using SoftUniBazar.Models;

namespace SoftUniBazar.Services.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<CategoryDropdownViewModel> GetAllCategories();
    }
}
