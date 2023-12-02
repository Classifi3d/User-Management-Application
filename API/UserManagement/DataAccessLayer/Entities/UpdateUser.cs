
namespace DataAccessLayer.Entities
{
    public class UpdateUser
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string First_Name { get; set; } = string.Empty;
        public string Last_Name { get; set; } = string.Empty;
        public byte Type_id { get; set; } = byte.MinValue;
    }
}
