using BrandCase.Core.DTOs;
using BrandCase.Core.Entities;
using BrandCase.Core.Interfaces;
using BrandCase.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BrandCase.Infrastructure.Services;

public class BrandService : IBrandService
{
    private readonly AppDbContext _context;

    public BrandService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Brand>> GetAllAsync()
    {
        return await _context.Brands.ToListAsync();
    }

    public async Task AddAsync(Brand brand)
    {
        _context.Brands.Add(brand);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteByIdsAsync(int[] ids)
    {
        var brands = await _context.Brands
            .Where(b => ids.Contains(b.Id))
            .ToListAsync();

        _context.Brands.RemoveRange(brands);
        await _context.SaveChangesAsync();
    }

    public async Task<PagedResult<Brand>> GetByPageAsync(int currentPage, int pageSize)
    {
        var totalCount = await _context.Brands.CountAsync();

        var rows = await _context.Brands
            .Skip((currentPage - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PagedResult<Brand>
        {
            TotalCount = totalCount,
            Rows = rows
        };
    }

    public async Task<PagedResult<Brand>> GetByPageAndConditionAsync(
        int currentPage, int pageSize, BrandQueryDto query)
    {
        var queryable = _context.Brands.AsQueryable();

        // 品牌名称模糊查询
        if (!string.IsNullOrWhiteSpace(query.BrandName))
        {
            queryable = queryable.Where(b => b.BrandName != null &&
                b.BrandName.Contains(query.BrandName));
        }

        // 企业名称模糊查询
        if (!string.IsNullOrWhiteSpace(query.CompanyName))
        {
            queryable = queryable.Where(b => b.CompanyName != null &&
                b.CompanyName.Contains(query.CompanyName));
        }

        // 状态精确查询
        if (query.Status.HasValue)
        {
            queryable = queryable.Where(b => b.Status == query.Status);
        }

        var totalCount = await queryable.CountAsync();

        var rows = await queryable
            .Skip((currentPage - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PagedResult<Brand>
        {
            TotalCount = totalCount,
            Rows = rows
        };
    }
}
