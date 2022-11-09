namespace Shared.Models;

public class Package {
    public int Id { get; set; }
    public int OrderId { get; set; }
    public string Destination { get; set; }
    public DateTime TimeStamp { get; set; }
}