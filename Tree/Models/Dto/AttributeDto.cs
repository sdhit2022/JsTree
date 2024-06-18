using System.ComponentModel.DataAnnotations;

namespace Tree.Models.Dto
{
    public class AttributeDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int Code { get; set; }
        [MaxLength(300)]
        [Required]
        public string Title { get; set; }
        [Required]
        public bool IsGood { get; set; }
    }
}
