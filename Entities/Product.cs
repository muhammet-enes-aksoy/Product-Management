using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProductManagement.Common;

namespace ProductManagement.Entities;

public class Product{

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; } = ""; 
    public int CategoryId { get; set; }
    public int Price { get; set; }
    
}