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
            return await _context.Project.Include(p => p.ProjectUsers).ThenInclude(pu => pu.User).ToListAsync();
        }

        public async Task<bool> DeleteProjectAsync(int projectId)
        {
            var project = await _context.Project.FindAsync(projectId);

            if (project == null)
            {
                return false; // not exist
            }

            _context.Project.Remove(project);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateProjectAsync(int projectId, ProjectCreateRequest request)
        {
            var project = await _context.Project.Include(p => p.ProjectUsers).FirstOrDefaultAsync(p => p.Id == projectId);

            if (project == null) return false;

            project.ProjectName = request.ProjectName;
            project.ProjectDesc = request.ProjectDescription;

            // Usuń istniejące przypisania
            _context.Project2User.RemoveRange(project.ProjectUsers);

            // Dodaj nowe przypisania
            foreach (var userId in request.UserIds)
            {
                _context.Project2User.Add(new Project2User { ProjectId = projectId, UserId = userId });
            }

            await _context.SaveChangesAsync();
            return true;
        }
    }
}