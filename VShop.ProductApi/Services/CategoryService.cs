using AutoMapper;
using VShop.ProductApi.DTOs;
using VShop.ProductApi.Models;
using VShop.ProductApi.Repositories;

namespace VShop.ProductApi.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CategoryDTO>> GetCategories()
    {
        var categoriesEntity = await _categoryRepository.GetAll();
        return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
    }

    public async Task<IEnumerable<CategoryDTO>> GetCategoriesProducts()
    {
        var categoriesEntity = await _categoryRepository.GetCategoryProducts();
        return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
    }

    public async Task<CategoryDTO> GetCategoryById(int id)
    {
        var categoriesEntity = await _categoryRepository.GetCategoryById(id);
        return _mapper.Map<CategoryDTO>(categoriesEntity);
    }
    public async Task AddCategory(CategoryDTO categoryDTO)
    {
        var categoriesEntity = _mapper.Map<Category>(categoryDTO);
        await _categoryRepository.Create(categoriesEntity);
        categoryDTO.CategoryId = categoriesEntity.CategoryId;
    }

    public async Task UpdateCategory(CategoryDTO categoryDTO)
    {
        var categoriesEntity = _mapper.Map<Category>(categoryDTO);
        await _categoryRepository.Update(categoriesEntity);
    }

    public async Task RemoveCategory(int id)
    {
        var categoriesEntity = _categoryRepository.GetCategoryById(id).Result;
        await _categoryRepository.Delete(categoriesEntity.CategoryId);
    }
}
