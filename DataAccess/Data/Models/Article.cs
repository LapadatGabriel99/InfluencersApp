using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Data.Models
{
    public partial class Article
    {
        public Article()
        {
            ArticleTags = new HashSet<ArticleTags>();
        }

        public int Id { get; set; }

        public int AuthorId { get; set; }
        
        public string Title { get; set; }
        
        public string Content { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }

        public virtual Author Author { get; set; }

        public virtual IEnumerable<ArticleTags> ArticleTags { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
