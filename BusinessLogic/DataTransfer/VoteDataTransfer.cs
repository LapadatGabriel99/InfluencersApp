using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.DataTransfer
{
    public class VoteDataTransfer
    {
        public int Score { get; set; }

        public int ArticleId { get; set; }

        public bool Succeded { get; set; }
    }
}
