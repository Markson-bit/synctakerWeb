namespace synctakerAPI.Core
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<int?> CreateProjectAsync(ProjectCreateRequest request)
        {
            return await _projectRepository.AddProjectAsync(request);
        }
    }
}