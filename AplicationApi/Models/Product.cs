using System.ComponentModel.DataAnnotations;
namespace AplicationApi.Models;
using System.ComponentModel;


public class Product
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name required")]
    [StringLength(30, MinimumLength = 3, ErrorMessage = "Product name must be between 3 and 30 characters")]
    public string NameProduct { get; set; } = "";

    [Required(ErrorMessage = "Description required")]
    [MaxLength(100, ErrorMessage = "Product description can't exceed 100 characters")]
    public string DescriptionProduct { get; set; } = "";

    [Required(ErrorMessage = "Price required")]
    [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Price must have up to 2 decimal places")]
    public decimal PriceProduct { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Stock can't be negative")]
    [DefaultValue(0)]
    public int StockProduct { get; set; } 

}