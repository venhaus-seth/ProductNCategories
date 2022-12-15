using System.ComponentModel.DataAnnotations;
#pragma warning disable CS8618
namespace ProductNCategories.Models;
public class Category
{   
    [Key]
	public int CategoryId {get;set;}
    [Required]
	public string Name {get;set;}
    public List<Connection> Connections {get;set;} = new List<Connection>();
	public DateTime CreatedAt { get; set; } = DateTime.Now;
	public DateTime UpdatedAt { get; set; } = DateTime.Now;
}