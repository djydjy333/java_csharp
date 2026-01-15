using BrandCase.Core.DTOs;
using BrandCase.Core.Entities;

namespace BrandCase.Core.Interfaces;

public interface IBrandService
{
    Task<List<Brand>> GetAllAsync();
    Task AddAsync(Brand brand);
    Task DeleteByIdsAsync(int[] ids);
    Task<PagedResult<Brand>> GetByPageAsync(int currentPage, int pageSize);
    Task<PagedResult<Brand>> GetByPageAndConditionAsync(int currentPage, int pageSize, BrandQueryDto query);
}
