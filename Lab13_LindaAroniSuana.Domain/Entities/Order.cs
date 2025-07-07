namespace Lab13_LindaAroniSuana.Domain.Entities;

public partial class Order
{
    public int OrderId { get; set; }

    public int ClientId { get; set; }

    public DateTime OrderDate { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual ICollection<Orderdetails> Orderdetails { get; set; } = new List<Orderdetails>();
}



