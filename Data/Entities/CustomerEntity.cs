using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class CustomerEntity
        //Beskriver och lagrar kundinformation i en databas och relaterar en kund till ett projekt
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public List<ProjectEntity> Projects { get; set; } = new List<ProjectEntity>();
    }
}
