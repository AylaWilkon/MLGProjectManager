using Data.Entities;

namespace MLGProjectManagerWeb.Models
{
    public static class ProjectEntityToProjectModelMapper
    {

        public static ProjectModel Map(ProjectEntity projectEntity)
        {
            return new ProjectModel
            {
                Id = projectEntity.Id,
                Title = projectEntity.Title,
                Description = projectEntity.Description,
                StartDate = projectEntity.StartDate,
                EndDate = projectEntity.EndDate,
                Status = projectEntity.Status,
                CustomerId = projectEntity.CustomerId,
                Rate = projectEntity.Rate,
                Responsible = projectEntity.Responsible,
            };
        }
    }
}
