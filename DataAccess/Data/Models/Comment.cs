using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Data.Models
{
    public partial class Comment
    {
        public int Id { get; set; }

        public int ArticleId { get; set; }

        public Article Article { get; set; }

        public string Content { get; set; }

        public string Nickname { get; set; }

        public DateTime PublishDate { get; set; }

        public Comment()
        {

        }
    }
}
