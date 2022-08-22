using System.ComponentModel.DataAnnotations;

namespace SchoolApi.Models
{
    public class UpdateGradeModel
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
