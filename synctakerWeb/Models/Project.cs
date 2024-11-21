namespace synctakerWeb.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDesc { get; set; }
        public ICollection<Project2User> ProjectUsers { get; set; } = new List<Project2User>();
    }
}