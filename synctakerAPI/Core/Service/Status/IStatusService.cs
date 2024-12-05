namespace synctakerAPI.Core
{
    public interface IStatusService
    {
        Task<List<Status>> GetAllStatusesAsync();
    }
}