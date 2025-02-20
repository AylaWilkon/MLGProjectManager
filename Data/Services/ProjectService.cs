using Data.Entities;
using Data.Repository.Interfaces;
using Data.Services.Interfaces;

namespace Services.ProjectService
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository ProjectRepository)
        {
            _projectRepository = ProjectRepository;
        }

        public async Task<int> AddProject(ProjectEntity projectEntity)
        {
            return await _projectRepository.AddAsync(projectEntity);
        }

        public async Task<int> UpdateProject(ProjectEntity projectEntity)
        {
            return await _projectRepository.UpdateAsync(projectEntity);
        }

        public async Task<ProjectEntity> Get(int Id)
        {
            return await _projectRepository.GetAsync(Id);
        }

        public async Task<List<ProjectEntity>> GetAll()
        {
            return await _projectRepository.GetAllAsync();
        }

        public async Task<int> Delete(int id)
        {
            return await _projectRepository.DeleteAsync(id);
        }
    }
}
