using System.ComponentModel.DataAnnotations;

namespace synctakerAPI.Core
{
    public class Project2User
    {
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}