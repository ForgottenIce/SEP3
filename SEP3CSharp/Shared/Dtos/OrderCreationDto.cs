using Shared.Models;

namespace Shared.Dtos;
public class OrderCreationDto {
    public Customer Customer { get; set; }
    public DateTime DateTimeOrdered { get; set; }
    public bool IsPacked { get; set; }
    public DateTime DateTimeSent { get; set; }
}
