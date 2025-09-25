public class Product
{
    private string _name;
    private string _productId;
    private decimal _pricePerUnit;
    private int _quantity;

    public Product(string name, string productId, decimal pricePerUnit, int quantity)
    {
        _name = name;
        _productId = productId;
        _pricePerUnit = pricePerUnit;
        _quantity = quantity;
    }

    public string Name { get => _name; set => _name = value; }
    public string ProductId { get => _productId; set => _productId = value; }
    public decimal pricePerUnit { get => _pricePerUnit; set => _pricePerUnit = value; }
    public int Quantity { get => _quantity; set => _quantity = value; }

    public decimal TotalCost()
    {
        return _pricePerUnit * _quantity;
    }
}