using System;
namespace Pets.Controllers.DTO.Feeding.Response
{
    public class ItemFeedingHistoryResponse
    {
        public string AnimalName { get; set; }

        public string FoodName { get; set; }

        public DateTime Date { get; set; }

        public int Count { get; set; }
    }
}
