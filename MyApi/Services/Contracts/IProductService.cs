using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Dto;
using Dto;

namespace Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductResponseDto>> GetAll(QueryMetaDto queryMetaDto);
        Task<ProductResponseDto> GetOne(Guid id);
        Task<ProductResponseDto> Create(CreateAddressDto addressDto);
        Task Update(Guid id, UpdateProductDto productDto);
        Task Delete(Guid id);
        Task<long> Count();
        Task<IEnumerable<string>> GetBrands(); 
        Task<IEnumerable<string>> GetColors(); 
        Task<IEnumerable<int>> GetMemories(); 
    }
}