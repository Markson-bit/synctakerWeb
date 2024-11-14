namespace synctakerAPI.Core
{
    public interface IProjectRepository
    {
        Task<int?> AddProjectAsync(ProjectCreateRequest request);
    }
}