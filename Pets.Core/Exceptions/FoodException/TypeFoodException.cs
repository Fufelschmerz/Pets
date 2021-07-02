using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pets.Core.Exceptions.FoodException
{
    public class TypeFoodException : Exception
    {
        private const string DefaultMessage = "Корм не подходит для этого типа животного";

        public TypeFoodException() : base(DefaultMessage) { }
    }
}
