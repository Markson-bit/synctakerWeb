namespace synctakerWeb.Models
{
    public class Task
    {
        public int Id { get; set; }
        public int StatusId { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public int? AssignedToId { get; set; }
        public int? ReviewerId { get; set; }
        public int? TestId { get; set; }
        public DateTime? RealizationPlanned { get; set; }
        public string Description { get; set; }

        // Relations
        public User AssignedTo { get; set; }

        public User Reviewer { get; set; }
        public User Tester { get; set; }
        public Status Status { get; set; }
    }
}