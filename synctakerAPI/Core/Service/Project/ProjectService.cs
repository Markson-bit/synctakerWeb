﻿namespace synctakerAPI.Core
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

        public async Task<List<Project>> GetAllProjectsAsync()
        {
            return await _projectRepository.GetAllProjectsAsync();
        }

        public async Task<bool> DeleteProjectAsync(int projectId)
        {
            return await _projectRepository.DeleteProjectAsync(projectId);
        }

        public async Task<bool> UpdateProjectAsync(int projectId, ProjectCreateRequest request)
        {
            return await _projectRepository.UpdateProjectAsync(projectId, request);
        }
    }
}