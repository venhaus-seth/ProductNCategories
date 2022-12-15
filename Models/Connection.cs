using System.ComponentModel.DataAnnotations;
#pragma warning disable CS8618
namespace ProductNCategories.Models;
public class Connection
{   
    [Key]
	public int ConnectionId {get;set;}
	public int ProductId {get;set;}
	public int CategoryId {get;set;}
	public Product? Product {get;set;}
	public Category? Category {get;set;}
	public DateTime CreatedAt { get; set; } = DateTime.Now;
	public DateTime UpdatedAt { get; set; } = DateTime.Now;
}