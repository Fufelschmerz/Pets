using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pets.Core.Exceptions.FoodException
{
    public class CountFoodException : Exception
    {
        private const string DefaultMessage = "Корма для кормления животного недостаточно";

        public CountFoodException() : base(DefaultMessage) { }
    }
}
