using Microsoft.EntityFrameworkCore;

namespace synctakerAPI.Core
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly AppDbContext _context;

        public ProjectRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int?> AddProjectAsync(ProjectCreateRequest request)
        {
            var project = new Project
            {
                ProjectName = request.ProjectName,
                ProjectDesc = request.ProjectDescription
            };

            _context.Project.Add(project);
            await _context.SaveChangesAsync();

            foreach (var userId in request.UserIds)
            {
                _context.Project2User.Add(new Project2User
                {
                    ProjectId = project.Id,
                    UserId = userId
                });
            }
            await _context.SaveChangesAsync();

            return project.Id;
        }

        public async Task<List<Project>> GetAllProjectsAsync()
        {
            return await _context.Project.ToListAsync();
        }
    }
}