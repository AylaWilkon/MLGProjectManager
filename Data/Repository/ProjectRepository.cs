using Data.Contexts;
using Data.Entities;
using Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Data.Repository
{
    public class ProjectRepository(DataContext context) : IProjectRepository
    {
        public async Task<int> AddAsync(ProjectEntity project)
        {
            try
            {
                project.ProjectNumber = ProjectNumber();


                context.Projects.Add(project);
                return await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error saving project: {ex.Message}");
                throw;
            }
        }

        public async Task<int> UpdateAsync(ProjectEntity project)
        {
            try
            {
                context.Projects.Update(project);
                return await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error saving project: {ex.Message}");
                throw;
            }
        }

        public async Task<List<ProjectEntity>> GetAllAsync()
        {
            return await context.Projects
                .Include(p => p.Customer).ToListAsync();
        }

        public async Task<ProjectEntity> GetAsync(int Id)
        {
            var project = await context.Projects.FirstOrDefaultAsync(p => p.Id == Id);

            return project;
        }

        private string ProjectNumber()
        {
            var dateTime = DateTime.Now;
            return $"P-{dateTime.Month}{dateTime.Day}{dateTime.Millisecond}";
        }

        public async Task<int> DeleteAsync(int id)
        {
            var projectEntity = await context.Projects.FindAsync(id);
            if (projectEntity != null)
            {
                try
                {
                    context.Projects.Remove(projectEntity);
                    await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error saving project: {ex.Message}");
                    throw;
                }

            }
            return 1;
        }
    }
}
