using System.Runtime.CompilerServices;
using System.Text;

public class Address
{
    private string _street;
    private string _city;
    private string _state;
    private string _country;

    public Address(string street, string city, string state, string country)
    {
        _street = street;
        _city = city;
        _state = state;
        _country = country;
    }
    public string Street { get => _street; set => _street = value; }
    public String City { get => _city; set => _city = value; }
    public string State { get => _state; set => _state = value; }
    public string Country { get => _country; set => _country = value; }

    public bool IsInUSA()
    {
        string c = _country?.Trim().ToLower() ?? "";
        return c == "usa" || c == "united states" || c == "united states of america" || c == "us";
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine(_street);
        sb.AppendLine($"{_city}, {_state}");
        sb.Append(_country);
        return sb.ToString();
    }
}