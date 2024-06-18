using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tree.Models
{
    public class RelAttribute
    {
        [Key]
        public int Id { get; set; }

        public int FkAttributeId { get; set; }
        public Attribute Attribute { get; set; }

        public int? FkAttributeParentId { get; set; }
        public Attribute? AttributeParent { get; set; }
    }
}
