using Data.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MLGProjectManagerWeb.Models
{
    public static class ProjectModelToProjectEntityMapper
    {
        public static ProjectEntity Map(ProjectModel projectModel, string projectNumber)
        {
            return new ProjectEntity
            {
                Id = projectModel.Id,
                Title = projectModel.Title,
                Description = projectModel.Description,
                StartDate = projectModel.StartDate,
                EndDate = projectModel.EndDate,
                Status = projectModel.Status,
                CustomerId = projectModel.CustomerId,
                Rate = projectModel.Rate,
                ProjectNumber = projectNumber,
                Responsible = projectModel.Responsible,
            };
        }
    }
}
