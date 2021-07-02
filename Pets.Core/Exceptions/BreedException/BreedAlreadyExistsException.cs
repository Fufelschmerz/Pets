using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pets.Core.Exceptions.BreedException
{
    public class BreedAlreadyExistsException : Exception
    {
        private const string DefaultMessage = "Такая порода уже существует";

        public BreedAlreadyExistsException() : base(DefaultMessage) { }
    }
}
