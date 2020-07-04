using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.DataTransfer
{
    public class RankingDataTransfer
    {
        public string AuthorNickname { get; set; }

        public string AuthorEmail { get; set; }

        public int AuthorScore { get; set; }

        public int AuthorNumberOfArticles { get; set; }
    }
}
