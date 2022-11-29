namespace Shared.Models;

public class Order {
    public long Id { get; set; }
    public Customer Customer { get; set; }
    public DateTime DateTimeOrdered { get; set; }
    public bool IsPacked { get; set; }
    public DateTime DateTimeSent { get; set; }
}