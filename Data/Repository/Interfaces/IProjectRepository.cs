using Data.Entities;

namespace Data.Repository.Interfaces
{
    public interface IProjectRepository
    {
        public Task<int> AddAsync(ProjectEntity project);
        public Task<int> UpdateAsync(ProjectEntity project);
        public Task<List<ProjectEntity>> GetAllAsync();
        public Task<ProjectEntity> GetAsync(int Id);
        public Task<int> DeleteAsync(int id);
    }
}
