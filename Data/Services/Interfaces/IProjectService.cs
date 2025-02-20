using Data.Entities;
using Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services.Interfaces
{
    public interface IProjectService
    {
        public Task<int> AddProject(ProjectEntity projectEntity);
        public Task<int> UpdateProject(ProjectEntity projectEntity);
        public Task<ProjectEntity> Get(int Id);
        public Task<List<ProjectEntity>> GetAll();
        public Task<int> Delete(int id);
    }
}
