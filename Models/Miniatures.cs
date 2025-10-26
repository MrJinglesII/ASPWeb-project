using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace project.Models
{
    public class Miniatures
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [DisplayName("Table Ready")]
        public bool TableReady { get; set; } = false;
        public string? Description { get; set; }
    }
}
