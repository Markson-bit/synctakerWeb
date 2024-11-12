using System.ComponentModel.DataAnnotations;

namespace synctakerAPI.Core
{
    public class Project
    {
        [Key]
        public int Id { get; set; }

        public string ProjectName { get; set; }
        public string ProjectDesc { get; set; }
    }
}