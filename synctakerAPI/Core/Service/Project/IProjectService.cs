namespace synctakerAPI.Core
{
    public interface IProjectService
    {
        Task<int?> CreateProjectAsync(ProjectCreateRequest request);

        Task<List<Project>> GetAllProjectsAsync();

        Task<bool> DeleteProjectAsync(int projectId);

        Task<bool> UpdateProjectAsync(int projectId, ProjectCreateRequest request);
    }
}