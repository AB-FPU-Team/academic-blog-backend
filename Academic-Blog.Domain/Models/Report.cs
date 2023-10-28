using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic_Blog.Domain.Models
{
    public class Report
    {
        public Guid Id { get; set; }
        public string Content { get; set; } = null!;
        public Guid CommentId { get; set; } 
        public virtual Comment Comment { get; set; }
    }
}
