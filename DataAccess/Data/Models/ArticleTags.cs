﻿using System;
using System.Collections.Generic;

namespace DataAccess.Data.Models
{
    public partial class ArticleTags
    {
        public int ArticleId { get; set; }
        public int TagId { get; set; }
        public int Id { get; set; }

        public virtual Article Article { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
