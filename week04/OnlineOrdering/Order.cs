using System.Text;

public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public Customer Customer { get => _customer; set => _customer = value; }
    public IReadOnlyList<Product> Products => _products.AsReadOnly();

    public void AddProduct(Product product)
    {
        if (product != null)
            _products.Add(product);
    }

    private decimal ShippingCost()
    {
        return _customer != null && _customer.LivesInUSA() ? 5m : 35m;
    }
    public decimal TotalPrice()
    {
        decimal productsTotal = _products.Sum(p => p.TotalCost());
        return productsTotal + ShippingCost();
    }

    public string GetPackingLabel()
    {
        var sb = new StringBuilder();
        sb.AppendLine("Packing LAbel:");
        foreach (var p in _products)
        {
            sb.AppendLine($"{p.Name} (ID: {p.ProductId}) x {p.Quantity}");
        }
        return sb.ToString();
    }
    public string GetShippingLabel()
    {
        var sb = new StringBuilder();
        sb.AppendLine("Shipping Label: ");
        sb.AppendLine(_customer?.Name ?? "Unknown Customer");
        if (_customer?.Address != null)
            sb.AppendLine(_customer.Address.ToString());
        return sb.ToString();
    }
}