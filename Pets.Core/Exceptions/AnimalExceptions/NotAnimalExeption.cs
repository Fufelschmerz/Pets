﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pets.Core.Exceptions.AnimalExceptions
{
    public class NotAnimalExeption : Exception
    {
        private const string DefaultMessage = "Animal not found";

        public NotAnimalExeption() : base(DefaultMessage) { }
    }
}
