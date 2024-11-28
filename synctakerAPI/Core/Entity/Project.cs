using System.ComponentModel.DataAnnotations;

namespace synctakerAPI.Core
{
    public class Project
    {
        [Key]
        public int Id { get; set; }

        public string ProjectName { get; set; }
        public string ProjectDesc { get; set; }

        //public ICollection<Task> Tasks { get; set; } = new List<Task>();
        public ICollection<Task> Tasks { get; set; } = new List<Task>();

        public ICollection<Project2User> ProjectUsers { get; set; } = new List<Project2User>();
    }
}