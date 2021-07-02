using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pets.Controllers.DTO.Feeding.Response
{
    public class ItemFeedingHistoryShortResponse
    {
        public string FoodName { get; set; }

        public DateTime Date { get; set; }

        public int Count { get; set; }
    }
}
