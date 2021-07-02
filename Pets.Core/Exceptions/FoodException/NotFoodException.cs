using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pets.Core.Exceptions.FoodException
{
    public class NotFoodException : Exception
    {
        private const string DefaultMessage = "Корм не найден";

        public NotFoodException() : base(DefaultMessage) { }
    }
}
