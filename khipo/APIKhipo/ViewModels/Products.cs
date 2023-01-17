using Microsoft.EntityFrameworkCore;

namespace APIKhipo.ViewModels;

public class Products
{   
    public DateTime createdAt { get; set; }
    public string? name { get; set; }
    public float price { get; set; }
    public string? brand { get; set; }
    public DateTime updatedAt { get; set; }
    public long id { get; set; }
}