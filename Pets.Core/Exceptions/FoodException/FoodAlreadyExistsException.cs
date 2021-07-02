using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pets.Core.Exceptions.FoodException
{
    public class FoodAlreadyExistsException : Exception
    {
        private const string DefaultMessage = "Такой корм уже существует";

        public FoodAlreadyExistsException() : base(DefaultMessage) { }
    }
}
