using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce.Domain.Models;
using ECommerce.Domain.Repositories;
using ECommerce.Domain.Services;
using ECommerce.Domain.Services.Communication;

namespace ECommerce.Services
{
    public class ProductService: IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnityOfWork _unityOfWork;

        public ProductService(IProductRepository productRepository, IUnityOfWork unityOfWork)
        {
            _productRepository = productRepository;
            _unityOfWork = unityOfWork;
        }
        

        public async Task<ProductResponse> SaveAsync(Product product)
        {
            try
            {
                await _productRepository.AddAsync(product);
                await _unityOfWork.CompleteAsync();
                return new ProductResponse(product);

            }
            catch (Exception e)
            {
                return new ProductResponse($"An error occurred {e.Message}");
            }
            
        }

        public async Task<ProductResponse> UpdateAsync(int id, Product product)
        {
            try
            {
                var _product = await _productRepository.FindByIdAsync(id);
                
                if (_product == null) return new ProductResponse($"this product doesn't exists {id}");

                _product.Name = product.Name;
                _product.Price = product.Price;
                _product.Description = product.Description;
                _product.ImageUri = product.ImageUri;
                
                _productRepository.Update(_product);
                await _unityOfWork.CompleteAsync();

                return new ProductResponse(_product);

            }
            catch (Exception e)
            {
                return new ProductResponse($"An error occurred {e.Message}");
            }
        }

        public async Task<ProductResponse> DeleteAsync(int id)
        {
            try
            {
                var product = await _productRepository.FindByIdAsync(id);

                if (product == null) return new ProductResponse($"this product doesn't exists by {id}");
                
                _productRepository.Delete(product);
                await _unityOfWork.CompleteAsync();
                return new ProductResponse(product);
                
            }
            catch (Exception e)
            {
                return new ProductResponse($"An error occurred {e.Message}");
            }
        }

        public async Task<Product> FindByIdAsync(int id)
        {
            return await _productRepository.FindByIdAsync(id);
        }

        public async Task<IEnumerable<Product>> ListAsync()
        {
            return await _productRepository.ListAsync();
        }
    }
}
