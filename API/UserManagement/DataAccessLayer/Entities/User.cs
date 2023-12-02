namespace DataAccessLayer.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Salt { get; set; } = string.Empty;
        public string First_Name { get; set; } = string.Empty;
        public string Last_Name { get; set; } = string.Empty;
        public byte Type_id { get; set; } = byte.MinValue;
        public List<Countries>? Countries { get; set; }
        public User()
        {
            Countries = new List<Countries>();
        }

    }
}
