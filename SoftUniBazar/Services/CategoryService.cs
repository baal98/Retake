using AutoMapper;
using SoftUniBazar.Data;
using SoftUniBazar.Models;
using SoftUniBazar.Services.Interfaces;

namespace SoftUniBazar.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly BazarDbContext dbContext;
        private readonly IMapper mapper;

        public CategoryService(BazarDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public IEnumerable<CategoryDropdownViewModel> GetAllCategories()
        {
            var categories = this.dbContext.Categories.ToList();

            var viewModelCategories = this.mapper.Map<IEnumerable<CategoryDropdownViewModel>>(categories);

            return viewModelCategories;
        }
    }
}
