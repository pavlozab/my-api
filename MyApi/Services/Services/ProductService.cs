using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Data;
using Data.Dto;
using Entities;
using Dto;

namespace Services
{
    public class ProductService: IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductResponseDto>> GetAll(QueryMetaDto queryMetaDto)
        {
            var addresses = await _repository.GetAll(queryMetaDto);
            return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResponseDto>>(addresses);
        }

        public async Task<ProductResponseDto> GetOne(Guid id)
        {
            var address = await _repository.GetOne(id);
            return _mapper.Map<ProductResponseDto>(address);
        }

        public async Task<ProductResponseDto> Create(CreateAddressDto addressDto)
        {
            var product = _mapper.Map<Product>(addressDto);
            await _repository.Create(product);

            return _mapper.Map<ProductResponseDto>(product);
        }

        public async Task Update(Guid id, UpdateProductDto productDto)
        {
            var existingProduct = await  _repository.GetOne(id);

            if (existingProduct is null)
                throw new KeyNotFoundException("Product hasn't been found");
            
            _mapper.Map(productDto, existingProduct);
            
            await _repository.Update(existingProduct);
        }

        public async Task Delete(Guid id)
        {
            var existingProduct = await _repository.GetOne(id);

            if (existingProduct is null)
                throw new KeyNotFoundException("Product hasn't been found");

            await _repository.Delete(existingProduct);
        }

        public async Task<long> Count()
        {
            return await _repository.Count();
        }

        public async Task<IEnumerable<string>> GetBrands()
        {
            return await _repository.GetBrands();
        }

        public async Task<IEnumerable<string>> GetColors()
        {
            return await _repository.GetColors();
        }

        public async Task<IEnumerable<int>> GetMemories()
        {
            return await _repository.GetMemories();
        }
    }
}