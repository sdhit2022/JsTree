using System.ComponentModel.DataAnnotations;

namespace Tree.Models
{
    public class Attribute
    {
        [Key]
        public int Id { get; set; }
        public int Code { get; set; }
        [MaxLength(300)]
        public string Title { get; set; }
        public bool IsGood { get; set; }
      
        public ICollection<RelAttribute>? Parents { get; set; }
        public ICollection<RelAttribute> Children { get; set; }

    }
}
