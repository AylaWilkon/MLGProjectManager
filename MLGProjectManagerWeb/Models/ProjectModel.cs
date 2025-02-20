using Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace MLGProjectManagerWeb.Models
{
    public class ProjectModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CustomerId { get; set; }
        public string Status { get; set; } = null!;
        public decimal Rate { get; set; }
        public string Responsible { get; set; } = null!;
    }
}
