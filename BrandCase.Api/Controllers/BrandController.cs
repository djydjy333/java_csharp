using BrandCase.Core.DTOs;
using BrandCase.Core.Entities;
using BrandCase.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BrandCase.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BrandController : ControllerBase
{
    private readonly IBrandService _brandService;

    public BrandController(IBrandService brandService)
    {
        _brandService = brandService;
    }

    /// <summary>
    /// 查询所有品牌
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<List<Brand>>> GetAll()
    {
        var brands = await _brandService.GetAllAsync();
        return Ok(brands);
    }

    /// <summary>
    /// 新增品牌
    /// </summary>
    [HttpPost]
    public async Task<ActionResult> Add([FromBody] Brand brand)
    {
        await _brandService.AddAsync(brand);
        return Ok("success");
    }

    /// <summary>
    /// 批量删除品牌
    /// </summary>
    [HttpDelete]
    public async Task<ActionResult> DeleteByIds([FromBody] int[] ids)
    {
        await _brandService.DeleteByIdsAsync(ids);
        return Ok("success");
    }

    /// <summary>
    /// 分页查询
    /// </summary>
    [HttpGet("page")]
    public async Task<ActionResult<PagedResult<Brand>>> GetByPage(
        [FromQuery] int currentPage = 1,
        [FromQuery] int pageSize = 10)
    {
        var result = await _brandService.GetByPageAsync(currentPage, pageSize);
        return Ok(result);
    }

    /// <summary>
    /// 分页条件查询
    /// </summary>
    [HttpPost("page")]
    public async Task<ActionResult<PagedResult<Brand>>> GetByPageAndCondition(
        [FromQuery] int currentPage = 1,
        [FromQuery] int pageSize = 10,
        [FromBody] BrandQueryDto query = null!)
    {
        query ??= new BrandQueryDto();
        var result = await _brandService.GetByPageAndConditionAsync(currentPage, pageSize, query);
        return Ok(result);
    }
}
