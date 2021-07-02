using System;

namespace Pets.Core.Exceptions.AnimalExceptions
{
    public class AnimalAlreadyExistsException : Exception
    {
        private const string DefaultMessage = "Животное с такими параметрами уже существует";

        public AnimalAlreadyExistsException() : base(DefaultMessage) { }
    }
}
