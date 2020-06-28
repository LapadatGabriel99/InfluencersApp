﻿using System;
using System.Collections.Generic;

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
    }
}