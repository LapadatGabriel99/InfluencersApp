using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Data.Models
{
    public partial class Tag
    {
        public Tag()
        {
            ArticleTags = new HashSet<ArticleTags>();
        }

        public int Id { get; set; }
        
        public string Name { get; set; }

        public virtual ICollection<ArticleTags> ArticleTags { get; set; }
    }
}
