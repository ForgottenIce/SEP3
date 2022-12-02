namespace Shared.Dtos;

public class CreateCustomerDto
{
    public long Id { get; set; }
    public string FullName { get; set; }
    public string PhoneNo { get; set; }
    public string Address { get; set; }
    public string Mail { get; set; }
}