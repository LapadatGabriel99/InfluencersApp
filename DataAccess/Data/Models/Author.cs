using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Data.Models
{
    public partial class Author
    {
        public Author()
        {
            Article = new HashSet<Article>();
        }

        public int Id { get; set; }
        
        public string Nickname { get; set; }
        
        public string Email { get; set; }

        public int? Votes { get; set; }

        public virtual ICollection<Article> Article { get; set; }
    }
}
