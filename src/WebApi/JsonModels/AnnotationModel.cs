using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.JsonModels
{
    public class AnnotationModel
    {
        public string Url { get; set; }
        public int AnnotationId { get; set; }
        public int PostId { get; set; }
        public string CommentBody { get; set; }
    }
}
