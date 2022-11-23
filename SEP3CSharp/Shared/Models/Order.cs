namespace Shared.Models;

public class Order {
    public int Id { get; set; }
    public Customer customer { get; set; }
    public DateTime DateTimeOrdered { get; set; }
    public bool IsPacked { get; set; }
    public DateTime DateTimeSent { get; set; }
}