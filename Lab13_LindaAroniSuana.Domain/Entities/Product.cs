namespace Lab13_LindaAroniSuana.Domain.Entities;

public partial class Product
{
    public int ProductId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public virtual ICollection<Orderdetails> Orderdetails { get; set; } = new List<Orderdetails>();
}

