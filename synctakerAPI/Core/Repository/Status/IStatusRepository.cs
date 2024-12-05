namespace synctakerAPI.Core
{
    public interface IStatusRepository
    {
        Task<List<Status>> GetAllStatusesAsync();
    }
}