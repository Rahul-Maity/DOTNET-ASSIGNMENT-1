using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DOTNET_ASSIGNMENT_1.Models
{
    public class Item
    {
        public int Id { get; set; }   
        public string key { get; set; }
        public string value { get; set; }
    }
}
