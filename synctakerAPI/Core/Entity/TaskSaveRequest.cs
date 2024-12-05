namespace synctakerApi.Core
{
    public class TaskSaveRequest
    {
        public int TaskId { get; set; }
        public string Priority { get; set; }
        public int StatusId { get; set; }
        public int ProjectId { get; set; }
        public int? AssignedToId { get; set; }
        public int? ReviewerId { get; set; }
        public int? TesterId { get; set; }
        public DateTime? RealizationPlanned { get; set; }
        public string Description { get; set; }
    }
}