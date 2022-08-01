using AutoMapper;
using VShop.ProductApi.DTOs;
using VShop.ProductApi.Models;
using VShop.ProductApi.Repositories;

namespace VShop.ProductApi.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductDTO>> GetProducts()
    {
        var productsEntity = await _productRepository.GetAll();
        return _mapper.Map<IEnumerable<ProductDTO>>(productsEntity);
    }

    public async Task<ProductDTO> GetProductById(int id)
    {
        var productsEntity = await _productRepository.GetProductById(id);
        return _mapper.Map<ProductDTO>(productsEntity);
    }

    public async Task AddProduct(ProductDTO productDTO)
    {
        var productsEntity = _mapper.Map<Product>(productDTO);
        await _productRepository.Create(productsEntity);
        productDTO.CategoryId = productsEntity.CategoryId;
    }

    public async Task UpdateProduct(ProductDTO productDTO)
    {
        var productsEntity = _mapper.Map<Product>(productDTO);
        await _productRepository.Update(productsEntity);
    }

    public async Task RemoveProduct(int id)
    {
        var productsEntity = _productRepository.GetProductById(id).Result;
        await _productRepository.Delete(productsEntity.CategoryId);
    }
}
