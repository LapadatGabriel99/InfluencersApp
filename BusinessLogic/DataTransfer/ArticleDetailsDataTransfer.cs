using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic.DataTransfer
{
    public class ArticleDetailsDataTransfer
    {
        public int ArticleId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string AuthorNickname { get; set; }

        public DateTime CreationDate { get; set; }

        public string AuthorEmail { get; set; }

        public IEnumerable<string> ArticleTags { get; set; }
        
        public string Tag { get; set; }

        public List<KeyValuePair<string,string>> Comments { get; set; }
    }
}
