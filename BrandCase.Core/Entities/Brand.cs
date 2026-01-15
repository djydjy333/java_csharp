using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrandCase.Core.Entities;

[Table("tb_brand")]
public class Brand
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("brand_name")]
    public string? BrandName { get; set; }

    [Column("company_name")]
    public string? CompanyName { get; set; }

    [Column("ordered")]
    public int? Ordered { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("status")]
    public int? Status { get; set; }

    [NotMapped]
    public string StatusStr => Status switch
    {
        0 => "禁用",
        1 => "启用",
        _ => "未知"
    };
}
