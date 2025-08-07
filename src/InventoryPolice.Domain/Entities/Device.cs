namespace InventoryPolice.Domain.Entities;

public class Device
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string SerialNumber { get; set; } = string.Empty;
    public int? OfficerId { get; set; }
    public Officer? Officer { get; set; }
    public int? DistrictId { get; set; }
    public District? District { get; set; }
}
