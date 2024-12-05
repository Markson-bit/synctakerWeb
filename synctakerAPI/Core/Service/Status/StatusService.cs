namespace synctakerAPI.Core
{
    public class StatusService : IStatusService
    {
        private readonly IStatusRepository _statusRepository;

        public StatusService(IStatusRepository statusRepository)
        {
            _statusRepository = statusRepository;
        }

        public async Task<List<Status>> GetAllStatusesAsync()
        {
            return await _statusRepository.GetAllStatusesAsync();
        }
    }
}