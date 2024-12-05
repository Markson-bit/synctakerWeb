namespace synctakerWeb.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool AdminRights { get; set; }
        public ICollection<Project2User> ProjectUsers { get; set; } = new List<Project2User>();

    }
}