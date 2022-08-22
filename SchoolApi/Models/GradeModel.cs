using System.ComponentModel.DataAnnotations;

namespace SchoolApi.Models
{
    public class GradeModel
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
