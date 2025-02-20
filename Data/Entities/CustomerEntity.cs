using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class CustomerEntity
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public List<ProjectEntity> Projects { get; set; } = new List<ProjectEntity>();
    }
}
