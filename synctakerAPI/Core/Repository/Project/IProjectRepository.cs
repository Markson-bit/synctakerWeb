namespace synctakerAPI.Core
{
    public interface IProjectRepository
    {
        Task<int?> AddProjectAsync(ProjectCreateRequest request);

        Task<List<Project>> GetAllProjectsAsync();

        Task<bool> DeleteProjectAsync(int projectId);

        Task<bool> UpdateProjectAsync(int projectId, ProjectCreateRequest request);
    }
}