using StackOverFLow.DomainModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModel
{
    public class Annotation
    {
        [Key]
        public int AnnotationId { get; set; }

        [ForeignKey("Post")]
        public int PostId { get; set; }
        public virtual Post Post { get; set; }

        public string CommentBody { get; set; }
    }
}
