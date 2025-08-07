namespace InventoryPolice.Api.Models
{
    public class District
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<Device> Devices { get; set; } = new List<Device>();
    }
}
