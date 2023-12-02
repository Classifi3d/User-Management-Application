namespace DataAccessLayer.Entities
{
    public class Countries
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Flag { get; set; } = string.Empty;
        public List<User> Users { get; set; }
        public Countries()
        {
            Users = new List<User>();
        }
    }
}
