namespace synctakerAPI.Core
{
    public interface IProjectService
    {
        Task<int?> CreateProjectAsync(ProjectCreateRequest request);
    }
}