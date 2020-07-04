using BusinessLogic.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Models
{
    public class RankingViewModel
    {
        public IEnumerable<RankingDataTransfer> RankingData { get; set; }
    }
}
