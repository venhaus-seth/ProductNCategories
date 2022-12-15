using System.ComponentModel.DataAnnotations;
#pragma warning disable CS8618
namespace ProductNCategories.Models;
public class Product
{
    [Key]
	public int ProductId {get;set;}
    [Required]
	public string Name {get;set;}
    [Required]
	public string Description {get;set;}
    [Required]
	public double Price {get;set;}
    public List<Connection> Connections {get;set;} = new List<Connection>();
	public DateTime CreatedAt { get; set; } = DateTime.Now;
	public DateTime UpdatedAt { get; set; } = DateTime.Now;
}