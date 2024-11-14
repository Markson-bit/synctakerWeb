namespace synctakerWeb.Models
{
    public class ProjectCreateRequest
    {
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public List<int> UserIds { get; set; } = new List<int>();
    }
}